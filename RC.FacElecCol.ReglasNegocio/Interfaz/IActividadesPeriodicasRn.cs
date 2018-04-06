namespace RC.FacElecCol.ReglasNegocio.Interfaz
{
    using Modelo.Entidades;
    using System.Collections.Generic;
    using System.Threading;

    public interface IActividadesPeriodicasRn
    {
        IEnumerable<ActividadesPeriodicasDto> CargarTodo();
        bool ConsultarTodasActividadesPeriodicas();
    }
}
