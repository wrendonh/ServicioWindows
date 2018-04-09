namespace RC.FacElecCol.ReglasNegocio.Interfaz
{
    using Modelo.Entidades;

    public interface IActividadesRn
    {        
        bool CambiarEstadoActividadesEnEjecucionANinguno();
        ActividadesDto CargarActividadPorId(int idActividad);
    }
}
