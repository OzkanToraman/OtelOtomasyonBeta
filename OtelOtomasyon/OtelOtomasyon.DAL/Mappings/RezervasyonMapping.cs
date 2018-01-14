using OtelOtomasyon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.DAL.Mappings
{
  public  class RezervasyonMapping:EntityTypeConfiguration<Rezervasyon>
    {
        public RezervasyonMapping()
        {
            ToTable("Rezervasyon");
            HasKey<int>(x => x.Id);

            Property(x => x.GirisTarihi)
            .HasColumnType("date")
            .HasColumnOrder(3)
            .IsRequired();

            Property(x => x.CikisTarihi)
            .HasColumnType("date")
            .HasColumnOrder(4)
            .IsRequired();

        }

        }
    }
