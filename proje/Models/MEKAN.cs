namespace proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("MEKAN")]
    public partial class MEKAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MEKAN()
        {
            CALISMA_SAATI = new HashSet<CALISMA_SAATI>();
            FIRSATs = new HashSet<FIRSAT>();
            FIRSAT_GALERI = new HashSet<FIRSAT_GALERI>();
            GALERIs = new HashSet<GALERI>();
            YORUMs = new HashSet<YORUM>();
        }

        [Key]
        public int MEKAN_ID { get; set; }

        public int KATEGORI_ID { get; set; }

        public int ALT_KATEGORI_ID { get; set; }

        public int IL_ID { get; set; }

        public int ILCE_ID { get; set; }

        [StringLength(50, ErrorMessage = "En fazla 50 karakter giriniz")]
        public string MEKAN_ADI { get; set; }

        [StringLength(50, ErrorMessage = "En fazla 50 karakter giriniz")]
        public string ADRES { get; set; }


        [AllowHtml]//ckeditorde yaptýðým deðiþikliði görmesi için
        [Required(ErrorMessage = "Açýklama giriniz")]
        public string ACIKLAMA { get; set; }

        public TimeSpan HAFTAICI_ACILIS { get; set; }

        public TimeSpan HAFTAICI_KAPANIS { get; set; }

        public TimeSpan HAFTASONU_ACILIS { get; set; }

        public TimeSpan HAFTASONU_KAPANIS { get; set; }

        [Required]
        [StringLength(50)]
        public string KULLANICI_ADI { get; set; }

        [Required]
        [StringLength(50)]
        public string SIFRE { get; set; }

        public bool DURUMU { get; set; }

        [Required]
        [StringLength(50)]
        public string MAIL { get; set; }

        public int TELEFON { get; set; }

        [Required]
        [StringLength(50)]
        public string ILGILI_KISI { get; set; }

        public virtual ALT_KATEGORI ALT_KATEGORI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CALISMA_SAATI> CALISMA_SAATI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FIRSAT> FIRSATs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FIRSAT_GALERI> FIRSAT_GALERI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GALERI> GALERIs { get; set; }

        public virtual IL IL { get; set; }

        public virtual ILCE ILCE { get; set; }

        public virtual KATEGORI KATEGORI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YORUM> YORUMs { get; set; }
    }
}
