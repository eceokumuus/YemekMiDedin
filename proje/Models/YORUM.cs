namespace proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YORUM")]
    public partial class YORUM
    {
        [Key]
        public int YORUM_ID { get; set; }

        public int? UYE_ID { get; set; }

        public int? MEKAN_ID { get; set; }

        [StringLength(200)]
        public string ICERIK { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TARIH { get; set; }

        public int? PUAN_DERECESI { get; set; }

        public bool? DURUMU { get; set; }

        public virtual MEKAN MEKAN { get; set; }

        public virtual UYE UYE { get; set; }
    }
}
