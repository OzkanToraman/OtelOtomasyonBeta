using OtelOtomasyon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.DAL.Mappings
{
   public class PersonelMapping: EntityTypeConfiguration<Personel>
    {
        public PersonelMapping()
        {
            ToTable("Personel");
            HasKey<int>(x => x.Id);

            Property(x => x.AdSoyad)
            .HasColumnType("nvarchar")
            .HasColumnOrder(2)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(50);

            Property(x => x.DogumTarihi)
            .HasColumnType("date")
            .HasColumnOrder(3)
            .IsRequired();

            Property(x => x.TCNo)
           .HasColumnType("nvarchar")
           .HasColumnOrder(4)
           .IsRequired()           
           .HasMaxLength(11);

            Property(x => x.Cinsiyet)
          .HasColumnType("bit")
          .HasColumnOrder(5)
          .IsOptional();

            Property(x => x.Adres)
          .HasColumnType("nvarchar")
          .HasColumnOrder(6)
          .IsOptional()
          .IsUnicode()
          .HasMaxLength(200);

            Property(x => x.Aktif)
          .HasColumnType("bit")
          .HasColumnOrder(7)
          .IsRequired();

            Property(x => x.IseGirisTarihi)
          .HasColumnType("date")
          .HasColumnOrder(8)
          .IsRequired();

            Property(x => x.Telefon)
          .HasColumnType("nvarchar")
          .HasColumnOrder(9)
          .IsRequired()
          .HasMaxLength(20);


           
        }
    }
}
