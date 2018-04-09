namespace RC.FacElecCol.Modelo.Entidades
{
    using System;

    public class ActividadesDto
    {
        public int IdActividad { get; set; }
        public int CodigoTarea { get; set; }
        public DateTime? FechaUltimaEjecucion { get; set; }
        public bool ForzarActividad { get; set; }
        public int CodigoEstado { get; set; }
        public string Error { get; set; }
        public bool CorrerAsincronamente { get; set; }
        public bool EsPeriodica { get; set; }
        public bool PorEjecutar { get; set; }

        #region ActividadesPeriodicas
        public int PeriodicidadEnMinutos { get; set; }
        #endregion

        #region ActividadesProgramadas
        public DateTime HoraProgramadaEjecucion { get; set; }
        #endregion
    }
}
