namespace OtelOtomasyon.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjectContext : DbContext
    {
        public ProjectContext()
            : base("name=ProjectContext")
        {
        }

        public virtual DbSet<Cinsiyet> Cinsiyet { get; set; }
        public virtual DbSet<Fiyat> Fiyat { get; set; }
        public virtual DbSet<Kat> Kat { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<MedeniDurum> MedeniDurum { get; set; }
        public virtual DbSet<Mod> Mod { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<Oda> Oda { get; set; }
        public virtual DbSet<OdaTur> OdaTur { get; set; }
        public virtual DbSet<Ozellik> Ozellik { get; set; }
        public virtual DbSet<Personel> Personel { get; set; }
        public virtual DbSet<Rezervasyon> Rezervasyon { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Satis> Satis { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinsiyet>()
                .HasMany(e => e.Musteri)
                .WithRequired(e => e.Cinsiyet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cinsiyet>()
                .HasMany(e => e.Personel)
                .WithRequired(e => e.Cinsiyet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MedeniDurum>()
                .HasMany(e => e.Musteri)
                .WithRequired(e => e.MedeniDurum)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mod>()
                .HasMany(e => e.Rezervasyon)
                .WithRequired(e => e.Mod)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Musteri>()
                .Property(e => e.Soyad)
                .IsFixedLength();

            modelBuilder.Entity<Oda>()
                .HasMany(e => e.Rezervasyon)
                .WithRequired(e => e.Oda)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rezervasyon>()
                .HasMany(e => e.Satis)
                .WithRequired(e => e.Rezervasyon)
                .WillCascadeOnDelete(false);
        }
    }
}
