namespace RC.FacElecCol.Fachada.Implementacion
{
    using Interfaz;
    using Microsoft.Practices.Unity;
    using Modelo.Entidades;
    using RC.FacElecCol.Aspecto;
    using ReglasNegocio.Interfaz;
    using System.Collections.Generic;
    using System.Threading;

    [Excepcion]
    public class ActividadesPeriodicasFachada : BaseFachada, IActividadesPeriodicasFachada
    {
        [Dependency]
        public IActividadesPeriodicasRn ActividadesPeriodicasRn { get; set; }

        public IEnumerable<ActividadesPeriodicasDto> CargarTodo()
        {
            return ActividadesPeriodicasRn.CargarTodo();
        }

        public bool EjecutarTodasActividadesPeriodicas()
        {
            return ActividadesPeriodicasRn.ConsultarTodasActividadesPeriodicas();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
