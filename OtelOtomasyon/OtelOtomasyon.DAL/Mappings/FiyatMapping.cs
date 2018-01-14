using OtelOtomasyon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.DAL.Mappings
{
    public class FiyatMapping : EntityTypeConfiguration<Fiyat>
    {
        public FiyatMapping()
        {
            ToTable("Fiyat");
            HasKey<int>(x => x.Id);

            Property(x => x.FiyatTutar)
            .HasColumnType("int")
            .IsRequired()
            .HasColumnOrder(4);
        }
    }
}
