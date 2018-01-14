using OtelOtomasyon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.DAL.Mappings
{
  public  class OzellikMapping : EntityTypeConfiguration<Ozellik>
    {
        public OzellikMapping()
        {
            ToTable("Ozellik");
            HasKey<int>(x => x.Id);

            Property(x => x.OzellikAd)
            .HasColumnType("nvarchar")
            .HasColumnOrder(2)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(30);

            Property(x => x.Aciklama)
            .HasColumnType("nvarchar")
            .HasColumnOrder(3)
            .IsOptional()
            .IsUnicode()
            .HasMaxLength(200);
        }
    }
}
