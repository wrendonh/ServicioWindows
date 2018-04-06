namespace RC.FacElecCol.ReglasNegocio.Interfaz
{
    using Modelo.Entidades;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IActividadesRn
    {
        ConcurrentDictionary<int, Task> GetRunningTasks { get; }

        bool EjecutarActividad(ActividadesDto actividad);

        bool EjecutarActividadAsincronamente(ActividadesDto actividad, CancellationToken token);

        bool CambiarEstadoActividadesEnEjecucionANinguno();
    }
}
