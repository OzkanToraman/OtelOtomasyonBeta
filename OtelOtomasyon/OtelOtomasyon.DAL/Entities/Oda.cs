namespace OtelOtomasyon.DAL
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Oda")]
    public partial class Oda : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Oda()
        {
            Rezervasyon = new HashSet<Rezervasyon>();
        }

        [Required]
        [StringLength(20)]
        public string OdaAd { get; set; }

        public int Id { get; set; }

        public int FiyatId { get; set; }

        public int KatId { get; set; }

        public virtual Fiyat Fiyat { get; set; }

        public virtual Kat Kat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezervasyon> Rezervasyon { get; set; }
    }
}
