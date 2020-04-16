namespace proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CALISMA_SAATI
    {
        [Key]
        public int CALISMA_SAATI_ID { get; set; }

        public int MEKAN_ID { get; set; }

        public TimeSpan HAFTAICI_ACILIS { get; set; }

        public TimeSpan HAFTAICI_KAPANIS { get; set; }

        public TimeSpan HAFTASONU_ACILIS { get; set; }

        public TimeSpan HAFTASONU_KAPANIS { get; set; }

        public virtual MEKAN MEKAN { get; set; }
    }
}
