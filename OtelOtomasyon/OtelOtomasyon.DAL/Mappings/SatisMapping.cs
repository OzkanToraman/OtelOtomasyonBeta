using OtelOtomasyon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.DAL.Mappings
{
   public class SatisMapping : EntityTypeConfiguration<Satis>
    {
        public SatisMapping()
        {
            ToTable("Satis");
            HasKey<int>(x => x.Id);

            Property(x => x.SatisTarihi)
            .HasColumnType("date")
            .HasColumnOrder(5)
            .IsRequired();

            Property(x => x.Aktif)
           .HasColumnType("bit")
           .HasColumnOrder(6)
           .IsRequired();


        }
    }
}
