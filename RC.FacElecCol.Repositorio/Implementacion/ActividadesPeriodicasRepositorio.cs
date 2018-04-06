namespace RC.FacElecCol.Repositorio.Implementacion
{
    using Interfaz;
    using Modelo.Entidades;
    using Modelo.Entidades.RentingModel;
    using System.Collections.Generic;
    using System.Linq;

    public static class ActividadesPeriodicasRepositorio
    {
        public static IEnumerable<ActividadesPeriodicasDto> CargarTodo(this IGenericRepository<FeCActividadesPeriodicas> repository)
        {
            IEnumerable<ActividadesPeriodicasDto> actividadesPeriodicas = from actPer in repository.GetAll()
                                                                              join act in repository.GetRepository<FeCActividades>() on actPer.CodigoActividad equals act.IdActividad
                                                                              select new ActividadesPeriodicasDto
                                                                              {
                                                                                  IdActividad = act.IdActividad,
                                                                                  CodigoTarea = act.CodigoTarea,
                                                                                  CodigoEstado = act.CodigoEstado,
                                                                                  CorrerAsincronamente = act.CorrerAsincronamente,
                                                                                  Error = act.DescripcionError,
                                                                                  FechaUltimaEjecucion = act.FechaUltimaEjecucion,
                                                                                  ForzarActividad = act.ForzarActividad,
                                                                                  PeriodicidadEnMinutos = actPer.PeriodicidadEnMinutos
                                                                              };
            
            return actividadesPeriodicas;
        }
    }
}
