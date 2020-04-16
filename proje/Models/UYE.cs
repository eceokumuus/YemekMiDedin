namespace proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UYE")]
    public partial class UYE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UYE()
        {
            YORUMs = new HashSet<YORUM>();
        }

        [Key]
        public int UYE_ID { get; set; }

        public int IL_ID { get; set; }

        public int ILCE_ID { get; set; }

        [Required(ErrorMessage = "Ad Giriniz")]
        public string ADI { get; set; }

        [Required(ErrorMessage = "Soyad Giriniz")]
        public string SOYADI { get; set; }

        [Required(ErrorMessage = "Kullanýcý Adý Giriniz")]
        public string KULLANICI_ADI { get; set; }

        [Required(ErrorMessage = "Sifre Giriniz")]
        public string SIFRE { get; set; }

        [Required(ErrorMessage = "E-Posta Giriniz")]
        public string EPOSTA { get; set; }

        [Required(ErrorMessage = "Telefon Giriniz")]
        public string TELEFON { get; set; }


        [Required(ErrorMessage = "Durumu Bilgisini Giriniz")]
        public bool DURUMU { get; set; }

        public virtual IL IL { get; set; }

        public virtual ILCE ILCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YORUM> YORUMs { get; set; }
    }
}
