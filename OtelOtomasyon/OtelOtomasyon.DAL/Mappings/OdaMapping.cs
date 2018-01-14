using OtelOtomasyon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.DAL.Mappings
{
  public class OdaMapping:EntityTypeConfiguration<Oda>
    {
        public OdaMapping()
        {
            ToTable("Oda");
            HasKey<int>(x => x.Id);


            Property(x => x.OdaAd)
            .HasColumnType("nvarchar")
            .IsRequired()
            .IsUnicode()
            .HasColumnOrder(2)
            .HasMaxLength(20);

            Property(x => x.DoluMu)
            .HasColumnType("bit")
            .IsRequired()            
            .HasColumnOrder(4);
        }
    }
}
