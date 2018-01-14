using OtelOtomasyon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.DAL.Mappings
{
   public class RoleMapping : EntityTypeConfiguration<Role>
    {
        public RoleMapping()
        {
            ToTable("Role");
            HasKey<int>(x => x.Id);

            Property(x => x.RoleName)
            .HasColumnType("nvarchar")
            .HasColumnOrder(2)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(20);


        }
   }
}
