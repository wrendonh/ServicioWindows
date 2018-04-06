namespace RC.FacElecCol.Fachada.Interfaz
{
    using Modelo.Entidades;
    using System.Threading;

    public interface IActividadesFachada : IBaseFachada
    {
        bool ExecuteActivity(ActividadesDto actividad);
        bool ExecuteActivityAsync(ActividadesDto actividad, CancellationToken token);
        bool MarcarActividadesEnEjecucionAEstadoNinguno();
    }
}
