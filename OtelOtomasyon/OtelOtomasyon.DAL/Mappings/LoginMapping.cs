using OtelOtomasyon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.DAL.Mappings
{
   public  class LoginMapping : EntityTypeConfiguration<Login>
    {
        public LoginMapping()
        {
            ToTable("Login");
            HasKey<int>(x => x.Id);

            Property(x => x.UserName)
            .HasColumnType("nvarchar")
            .HasColumnOrder(2)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(50);

            Property(x=>x.Password)
            .HasColumnType("nvarchar")
            .HasColumnOrder(3)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(50);

        }
    }
}
