namespace RC.FacElecCol.ReglasNegocio.Implementacion
{
    using Interfaz;
    using Microsoft.Practices.Unity;
    using Modelo.Entidades;
    using Modelo.Entidades.RentingModel;
    using Repositorio.Implementacion;
    using Repositorio.UnitOfWork;
    using System.Collections.Generic;
    using System.Threading;

    public class ActividadesPeriodicasRn : IActividadesPeriodicasRn
    {
        /// <summary>
        /// Gets or sets the unit of work factory.
        /// </summary>
        /// <value>
        /// The unit of work factory.
        /// </value>
        [Dependency]
        public IUnitOfWorkFactory UnitOfWorkFactory { get; set; }

        public IEnumerable<ActividadesPeriodicasDto> CargarTodo()
        {
            using (var unitOfWork = UnitOfWorkFactory.GetUnitOfWork())
            {
                var repository = unitOfWork.GetGenericRepository<FeCActividadesPeriodicas>();
                return repository.CargarTodo();
            }
        }

        public bool ConsultarTodasActividadesPeriodicas()
        {
            throw new System.NotImplementedException();
        }
    }
}
