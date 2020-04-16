namespace proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Xml.Serialization;

    public partial class ALT_KATEGORI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ALT_KATEGORI()
        {
            MEKANs = new HashSet<MEKAN>();
        }

        [Key]
        public int ALT_KATEGORI_ID { get; set; }


        public int KATEGORI_ID { get; set; }

        [Required(ErrorMessage = "Alt Kategori Giriniz")]
        [StringLength(50)]
        public string ALT_KATEGORI_ADI { get; set; }

        public virtual KATEGORI KATEGORI { get; set; }

       
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEKAN> MEKANs { get; set; }
    }
}
