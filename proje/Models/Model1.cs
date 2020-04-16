namespace proje.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<ALT_KATEGORI> ALT_KATEGORI { get; set; }
        public virtual DbSet<CALISMA_SAATI> CALISMA_SAATI { get; set; }
        public virtual DbSet<FIRSAT> FIRSATs { get; set; }
        public virtual DbSet<FIRSAT_GALERI> FIRSAT_GALERI { get; set; }
        public virtual DbSet<GALERI> GALERIs { get; set; }
        public virtual DbSet<IL> ILs { get; set; }
        public virtual DbSet<ILCE> ILCEs { get; set; }
        public virtual DbSet<KATEGORI> KATEGORIs { get; set; }
        public virtual DbSet<MEKAN> MEKANs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UYE> UYEs { get; set; }
        public virtual DbSet<YONETICI> YONETICIs { get; set; }
        public virtual DbSet<YORUM> YORUMs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ALT_KATEGORI>()
                .Property(e => e.ALT_KATEGORI_ADI)
                .IsUnicode(false);

            modelBuilder.Entity<ALT_KATEGORI>()
                .HasMany(e => e.MEKANs)
                .WithRequired(e => e.ALT_KATEGORI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FIRSAT>()
                .Property(e => e.FIRSAT_ADI)
                .IsUnicode(false);

            modelBuilder.Entity<FIRSAT>()
                .Property(e => e.FIRSAT_DETAY)
                .IsUnicode(false);

            modelBuilder.Entity<FIRSAT>()
                .Property(e => e.NASIL_KULLANILIR)
                .IsUnicode(false);

            modelBuilder.Entity<FIRSAT_GALERI>()
                .Property(e => e.BASLIK)
                .IsUnicode(false);

            modelBuilder.Entity<FIRSAT_GALERI>()
                .Property(e => e.RESIM)
                .IsUnicode(false);

            modelBuilder.Entity<GALERI>()
                .Property(e => e.BASLIK)
                .IsUnicode(false);

            modelBuilder.Entity<GALERI>()
                .Property(e => e.LINK)
                .IsUnicode(false);

            modelBuilder.Entity<GALERI>()
                .Property(e => e.RESIM)
                .IsUnicode(false);

            modelBuilder.Entity<IL>()
                .Property(e => e.IL_ADI)
                .IsUnicode(false);

            modelBuilder.Entity<IL>()
                .HasMany(e => e.ILCEs)
                .WithRequired(e => e.IL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IL>()
                .HasMany(e => e.MEKANs)
                .WithRequired(e => e.IL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IL>()
                .HasMany(e => e.UYEs)
                .WithRequired(e => e.IL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ILCE>()
                .Property(e => e.ILCE_ADI)
                .IsUnicode(false);

            modelBuilder.Entity<ILCE>()
                .HasMany(e => e.MEKANs)
                .WithRequired(e => e.ILCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ILCE>()
                .HasMany(e => e.UYEs)
                .WithRequired(e => e.ILCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KATEGORI>()
                .Property(e => e.KATEGORI_ADI)
                .IsUnicode(false);

            modelBuilder.Entity<KATEGORI>()
                .HasMany(e => e.ALT_KATEGORI)
                .WithRequired(e => e.KATEGORI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KATEGORI>()
                .HasMany(e => e.MEKANs)
                .WithRequired(e => e.KATEGORI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MEKAN>()
                .Property(e => e.MEKAN_ADI)
                .IsUnicode(false);

            modelBuilder.Entity<MEKAN>()
                .Property(e => e.ADRES)
                .IsUnicode(false);

            modelBuilder.Entity<MEKAN>()
                .Property(e => e.ACIKLAMA)
                .IsUnicode(false);

            modelBuilder.Entity<MEKAN>()
                .Property(e => e.KULLANICI_ADI)
                .IsUnicode(false);

            modelBuilder.Entity<MEKAN>()
                .Property(e => e.SIFRE)
                .IsUnicode(false);

            modelBuilder.Entity<MEKAN>()
                .Property(e => e.MAIL)
                .IsUnicode(false);

            modelBuilder.Entity<MEKAN>()
                .Property(e => e.ILGILI_KISI)
                .IsUnicode(false);

            modelBuilder.Entity<MEKAN>()
                .HasMany(e => e.CALISMA_SAATI)
                .WithRequired(e => e.MEKAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MEKAN>()
                .HasMany(e => e.FIRSAT_GALERI)
                .WithRequired(e => e.MEKAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UYE>()
                .Property(e => e.ADI)
                .IsUnicode(false);

            modelBuilder.Entity<UYE>()
                .Property(e => e.SOYADI)
                .IsUnicode(false);

            modelBuilder.Entity<UYE>()
                .Property(e => e.KULLANICI_ADI)
                .IsUnicode(false);

            modelBuilder.Entity<UYE>()
                .Property(e => e.SIFRE)
                .IsUnicode(false);

            modelBuilder.Entity<UYE>()
                .Property(e => e.EPOSTA)
                .IsUnicode(false);

            modelBuilder.Entity<UYE>()
                .Property(e => e.TELEFON)
                .IsUnicode(false);

            modelBuilder.Entity<YONETICI>()
                .Property(e => e.YONETICI_ADI)
                .IsUnicode(false);

            modelBuilder.Entity<YONETICI>()
                .Property(e => e.SIFRE)
                .IsUnicode(false);

            modelBuilder.Entity<YORUM>()
                .Property(e => e.ICERIK)
                .IsUnicode(false);
        }
    }
}
