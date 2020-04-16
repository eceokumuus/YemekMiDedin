namespace proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FIRSAT")]
    public partial class FIRSAT
    {
        [Key]
        public int FIRSAT_ID { get; set; }

        [Required(ErrorMessage = "Fýrsat Adý Giriniz")]
        public string FIRSAT_ADI { get; set; }


        [Required(ErrorMessage = "Mekan Adý Giriniz")]
        public int MEKAN_ID { get; set; }

        [StringLength(200, ErrorMessage = "En fazla 200 karakter giriniz")]
        public string FIRSAT_DETAY { get; set; }

        [StringLength(200, ErrorMessage = "En fazla 200 karakter giriniz")]
        public string NASIL_KULLANILIR { get; set; }

        [Column(TypeName = "date")]
        public DateTime BITIS_TARIH { get; set; }

        public TimeSpan BITIS_SAAT { get; set; }

        public virtual MEKAN MEKAN { get; set; }
    }
}
