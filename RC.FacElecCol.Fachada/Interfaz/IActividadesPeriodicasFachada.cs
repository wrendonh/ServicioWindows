namespace RC.FacElecCol.Fachada.Interfaz
{
    using Modelo.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public interface IActividadesPeriodicasFachada : IDisposable, IBaseFachada
    {
        IEnumerable<ActividadesPeriodicasDto> CargarTodo();

        bool EjecutarTodasActividadesPeriodicas();
    }
}
