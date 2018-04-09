namespace RC.FacElecCol.Repositorio.Implementacion
{
    using Interfaz;
    using Modelo.Entidades.RentingModel;
    using RC.FacElecCol.Modelo.Entidades;
    using RC.FacElecCol.Modelo.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ActividadesRepositorio
    {
        public static List<FeCActividades> CargarTodo(this IGenericRepository<FeCActividades> repository)
        {
            IEnumerable<FeCActividades> actividades = from act in repository.GetAll()
                                                      select act;

            return actividades.ToList();
        }

        public static ActividadesDto CargarActividadPorId(this IGenericRepository<FeCActividades> repository, int codigoTarea)
        {
            IQueryable<FeCActividades> actividad = from act in repository.GetAll()
                                                   where act.CodigoTarea == codigoTarea
                                                   select act;

            bool esPeriodica = actividad.Select(x => x.EsPeriodica).FirstOrDefault();

            DateTime fechaActual = DateTime.Now;
            ActividadesDto actividadPorEjecutar;
            if (esPeriodica)
            {
                actividadPorEjecutar = (from act in actividad
                                        join actPer in repository.GetRepository<FeCActividadesPeriodicas>() on act.IdActividad equals actPer.CodigoActividad
                                        select new ActividadesDto()
                                        {
                                            CodigoEstado = act.CodigoEstado,
                                            CodigoTarea = act.CodigoTarea,
                                            FechaUltimaEjecucion = act.FechaUltimaEjecucion,
                                            ForzarActividad = act.ForzarActividad,
                                            PeriodicidadEnMinutos = actPer.PeriodicidadEnMinutos,
                                            IdActividad = act.IdActividad
                                        }).FirstOrDefault();

                if (actividadPorEjecutar.CodigoEstado == (int)EstadosActividades.EnProceso)
                {
                    return actividadPorEjecutar;
                }

                if (actividadPorEjecutar.ForzarActividad || !actividadPorEjecutar.FechaUltimaEjecucion.HasValue || (actividadPorEjecutar.FechaUltimaEjecucion.HasValue
                    && fechaActual >= actividadPorEjecutar.FechaUltimaEjecucion.Value.AddMinutes(actividadPorEjecutar.PeriodicidadEnMinutos)))
                {
                    actividadPorEjecutar.PorEjecutar = true;
                }

            }
            else
            {
                actividadPorEjecutar = (from act in actividad
                                        join actProg in repository.GetRepository<FeCActividadesProgramadas>() on act.IdActividad equals actProg.CodigoActividad
                                        select new ActividadesDto()
                                        {
                                            CodigoEstado = act.CodigoEstado,
                                            CodigoTarea = act.CodigoTarea,
                                            FechaUltimaEjecucion = act.FechaUltimaEjecucion,
                                            ForzarActividad = act.ForzarActividad,
                                            HoraProgramadaEjecucion = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day, actProg.Hora, actProg.Minuto, actProg.Segundo),
                                            IdActividad = act.IdActividad
                                        }).FirstOrDefault();


                if (actividadPorEjecutar.CodigoEstado == (int)EstadosActividades.EnProceso)
                {
                    return actividadPorEjecutar;
                }

                if (actividadPorEjecutar.ForzarActividad || (!actividadPorEjecutar.FechaUltimaEjecucion.HasValue && 
                    fechaActual >= actividadPorEjecutar.HoraProgramadaEjecucion))
                {
                    actividadPorEjecutar.PorEjecutar = true;
                }
                else
                {
                    if (actividadPorEjecutar.FechaUltimaEjecucion.HasValue)
                    {
                        if (actividadPorEjecutar.HoraProgramadaEjecucion.Day > actividadPorEjecutar.FechaUltimaEjecucion.Value.Day)
                        {
                            if (fechaActual >= actividadPorEjecutar.HoraProgramadaEjecucion)
                            {
                                actividadPorEjecutar.PorEjecutar = true;
                            }
                        }
                    }
                }
            }

            return actividadPorEjecutar;
        }
    }
}
