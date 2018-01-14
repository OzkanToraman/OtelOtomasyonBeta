namespace OtelOtomasyon.DAL
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OdaTur")]
    public partial class OdaTur : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OdaTur()
        {
            Fiyat = new HashSet<Fiyat>();
        }

        [Required]
        [StringLength(50)]
        public string TurAd { get; set; }

        [StringLength(200)]
        public string Aciklama { get; set; }

        public int Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fiyat> Fiyat { get; set; }
    }
}
