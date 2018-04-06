namespace RC.FacElecCol.ReglasNegocio.Implementacion
{
    using Interfaz;
    using Microsoft.Practices.Unity;
    using Modelo.Entidades;
    using Modelo.Entidades.RentingModel;
    using Modelo.Enums;
    using Repositorio.Implementacion;
    using Repositorio.Interfaz;
    using Repositorio.UnitOfWork;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class ActividadesRn : IActividadesRn
    {
        [Dependency]
        public IUnitOfWorkFactory UnitOfWorkFactory { get; set; }

        public ConcurrentDictionary<int, Task> GetRunningTasks { get; }

        public bool EjecutarActividad(ActividadesDto actividad)
        {
            throw new System.NotImplementedException();
        }

        public bool EjecutarActividadAsincronamente(ActividadesDto actividad, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }

        public bool CambiarEstadoActividadesEnEjecucionANinguno()
        {
            using (var unitOfWork = UnitOfWorkFactory.GetUnitOfWork())
            {
                IGenericRepository<FeCActividades> repository = unitOfWork.GetGenericRepository<FeCActividades>();
                List<FeCActividades> currentActivities = ObtenerActividades(repository);

                unitOfWork.BeginTransaction();
                List<FeCActividades> runningActivities = currentActivities.FindAll(x => x.CodigoEstado == (int)EstadosActividades.EnProceso).ToList();
                foreach (var activity in runningActivities)
                {                    
                    activity.CodigoEstado = (int)EstadosActividades.Ninguno;
                    repository.Update(activity);
                    repository.Save();
                }
                unitOfWork.Commit();
                return true;
            }
        }

        private List<FeCActividades> ObtenerActividades(IGenericRepository<FeCActividades> repository)
        {
            List<FeCActividades> actividades = repository.CargarTodo();
            return actividades;
        }
    }
}
