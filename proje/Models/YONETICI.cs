namespace proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YONETICI")]
    public partial class YONETICI
    {
        [Key]
        public int YONETICI_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string YONETICI_ADI { get; set; }

        [Required]
        [StringLength(50)]
        public string SIFRE { get; set; }

        public bool DURUMU { get; set; }
    }
}
