using OtelOtomasyon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.DAL.Mappings
{
    public class KatMapping:EntityTypeConfiguration<Kat>
    {
        public KatMapping()
        {
            ToTable("Kat");
            HasKey<int>(x => x.Id);

            Property(x => x.KatNo)
                .HasColumnType("int")
                .IsRequired()
                .HasColumnOrder(2); 
                

        }
    }
}
