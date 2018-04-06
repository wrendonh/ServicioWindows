namespace RC.FacElecCol.Modelo.Entidades.RentingModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FECActividadesProgramadas")]
    public class FeCActividadesProgramadas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]        
        public int CodigoActividad { get; set; }
                
        public int Hora { get; set; }
                
        public int Minuto { get; set; }
                
        public int Segundo { get; set; }

        public virtual FeCActividades Actividad { get; set; }
    }
}
