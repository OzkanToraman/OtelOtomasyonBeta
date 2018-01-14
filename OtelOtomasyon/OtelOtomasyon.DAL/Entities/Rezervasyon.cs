namespace OtelOtomasyon.DAL
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rezervasyon")]
    public partial class Rezervasyon : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rezervasyon()
        {
            Satis = new HashSet<Satis>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int OdaId { get; set; }

        public int ModId { get; set; }

        public bool DoluMu { get; set; }

        public bool RezerveMi { get; set; }

        [Column(TypeName = "date")]
        public DateTime GirisTarihi { get; set; }

        [Column(TypeName = "date")]
        public DateTime CikisTarihi { get; set; }

        public virtual Mod Mod { get; set; }

        public virtual Oda Oda { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Satis> Satis { get; set; }
    }
}
