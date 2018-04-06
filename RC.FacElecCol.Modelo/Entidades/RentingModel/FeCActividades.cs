namespace RC.FacElecCol.Modelo.Entidades.RentingModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FECActividades")]
    public class FeCActividades
    {        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]        
        public int IdActividad { get; set; }
                
        public int CodigoTarea { get; set; }
                
        public DateTime? FechaUltimaEjecucion { get; set; }
                
        public bool ForzarActividad { get; set; }
                
        public int CodigoEstado { get; set; }
                
        [StringLength(1000)]
        public string DescripcionError { get; set; }
        
        public bool CorrerAsincronamente { get; set; }

        public virtual FeCEstadosActividades EstadoActividad { get; set; }

        public virtual FeCTareas Tarea { get; set; }

        public virtual FeCActividadesProgramadas ActividadProgramada { get; set; }

        public virtual FeCActividadesPeriodicas ActividadPeriodica { get; set; }
    }
}