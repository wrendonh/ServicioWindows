namespace RC.FacElecCol.Fachada.Implementacion
{
    using Interfaz;
    using Microsoft.Practices.Unity;
    using Modelo.Entidades;
    using RC.FacElecCol.Aspecto;
    using ReglasNegocio.Interfaz;
    using System.Threading;

    [Excepcion]
    public class ActividadesFachada : BaseFachada, IActividadesFachada
    {
        [Dependency]
        public IActividadesRn ActividadesRn { get; set; }

        public bool ExecuteActivity(ActividadesDto actividad)
        {
            return ActividadesRn.EjecutarActividad(actividad);
        }

        public bool ExecuteActivityAsync(ActividadesDto actividad, CancellationToken token)
        {
            return ActividadesRn.EjecutarActividadAsincronamente(actividad, token);
        }

        public bool MarcarActividadesEnEjecucionAEstadoNinguno()
        {
            return ActividadesRn.CambiarEstadoActividadesEnEjecucionANinguno();
        }
    }
}
