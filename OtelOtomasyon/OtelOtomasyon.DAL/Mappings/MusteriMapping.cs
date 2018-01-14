using OtelOtomasyon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.DAL.Mappings
{
    public class MusteriMapping : EntityTypeConfiguration<Musteri>
    {
        public MusteriMapping()
        {
            ToTable("Musteri");
            HasKey<int>(x => x.Id);

            Property(x => x.AdSoyad)
           .HasColumnType("nvarchar")
           .HasColumnOrder(2)
           .IsRequired()
           .IsUnicode()
           .HasMaxLength(50);

           Property(x => x.TCNo)
          .HasColumnType("nvarchar")
          .HasColumnOrder(3)
          .IsRequired()
          .HasMaxLength(11);

            Property(x => x.DogumTarihi)
             .HasColumnType("date")
             .HasColumnOrder(4)
             .IsRequired();

            Property(x => x.Telefon)
            .HasColumnType("nvarchar")
            .HasColumnOrder(5)
            .IsRequired()
            .HasMaxLength(20);

            Property(x => x.MedeniDurum)
           .HasColumnType("bit")
           .HasColumnOrder(6)
           .IsOptional();

            Property(x => x.Cinsiyet)
            .HasColumnType("bit")
            .HasColumnOrder(7)
            .IsOptional();

            Property(x => x.AracPlaka)
                .HasColumnType("nvarchar")
                .HasMaxLength(10)
                .IsOptional(); 


        }
    }
}