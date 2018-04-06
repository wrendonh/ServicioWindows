namespace RC.FacElecCol.Modelo.Entidades.RentingModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FECTareas")]
    public class FeCTareas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FeCTareas()
        {
            Actividades = new HashSet<FeCActividades>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]        
        public int IdTarea { get; set; }

        [Required]
        [StringLength(200)]        
        public string strNombreTarea { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FeCActividades> Actividades { get; set; }
    }
}
