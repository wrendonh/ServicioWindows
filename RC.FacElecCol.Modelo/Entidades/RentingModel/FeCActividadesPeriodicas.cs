namespace RC.FacElecCol.Modelo.Entidades.RentingModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class FeCActividadesPeriodicas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]      
        public int CodigoActividad { get; set; }

        public int PeriodicidadEnMinutos { get; set; }

        public virtual FeCActividades Actividad { get; set; }
    }
}
