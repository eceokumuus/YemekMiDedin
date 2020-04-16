namespace proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ILCE")]
    public partial class ILCE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ILCE()
        {
            MEKANs = new HashSet<MEKAN>();
            UYEs = new HashSet<UYE>();
        }

        [Key]
        public int ILCE_ID { get; set; }

        public int IL_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ILCE_ADI { get; set; }

        public virtual IL IL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEKAN> MEKANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UYE> UYEs { get; set; }
    }
}
