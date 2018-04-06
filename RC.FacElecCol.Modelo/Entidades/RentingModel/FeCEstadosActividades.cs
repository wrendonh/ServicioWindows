namespace RC.FacElecCol.Modelo.Entidades.RentingModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FECEstadosActividades")]
    public class FeCEstadosActividades
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FeCEstadosActividades()
        {
            Actividades = new HashSet<FeCActividades>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]        
        public int IdEstado { get; set; }

        [Required]
        [StringLength(200)]        
        public string NombreEstado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FeCActividades> Actividades { get; set; }
    }
}
