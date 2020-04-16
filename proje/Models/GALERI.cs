namespace proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GALERI")]
    public partial class GALERI
    {
        [Key]
        public int GALERI_ID { get; set; }

        public int? MEKAN_ID { get; set; }


        [Required(ErrorMessage = "Baþlýk Adýnýz Giriniz")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter giriniz", MinimumLength = 0)]
        public string BASLIK { get; set; }

        public bool? DURUMU { get; set; }

        [StringLength(100)]
        public string LINK { get; set; }

        [StringLength(50)]
        public string RESIM { get; set; }

        [NotMapped]
        public string ResimDosyasi { get; set; }

        public virtual MEKAN MEKAN { get; set; }
    }
}
