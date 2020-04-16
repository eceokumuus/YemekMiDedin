namespace proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FIRSAT_GALERI
    {
        [Key]
        public int FIRSAT_GALERI_ID { get; set; }

        public int MEKAN_ID { get; set; }

        [Required(ErrorMessage = "Baþlýk Bilgisini Giriniz")]
        public string BASLIK { get; set; }

        public bool DURUMU { get; set; }

        [Required]
        [StringLength(50)]
        public string RESIM { get; set; }

        public virtual MEKAN MEKAN { get; set; }
    }
}
