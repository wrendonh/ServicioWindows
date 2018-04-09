namespace RC.FacElecCol.Fachada.Implementacion
{
    using Interfaz;
    using Microsoft.Practices.Unity;
    using Modelo.Entidades;
    using RC.FacElecCol.Aspecto;
    using ReglasNegocio.Interfaz;
    using System.Threading;
    using System;

    [Excepcion]
    public class ActividadesFachada : BaseFachada, IActividadesFachada
    {
        [Dependency]
        public IActividadesRn ActividadesRn { get; set; }

        public ActividadesDto CargarActividadPorId(int idActividad)
        {
            return ActividadesRn.CargarActividadPorId(idActividad);
        }

        public bool MarcarActividadesEnEjecucionAEstadoNinguno()
        {
            return ActividadesRn.CambiarEstadoActividadesEnEjecucionANinguno();
        }
    }
}
