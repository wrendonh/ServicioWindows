namespace RC.FacElecCol.Fachada.Interfaz
{
    using Modelo.Entidades;
    using System.Threading;

    public interface IActividadesFachada : IBaseFachada
    {
        bool MarcarActividadesEnEjecucionAEstadoNinguno();
        ActividadesDto CargarActividadPorId(int idActividad);
    }
}
