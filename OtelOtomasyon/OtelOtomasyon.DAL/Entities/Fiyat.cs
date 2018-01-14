namespace OtelOtomasyon.DAL
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fiyat")]
    public partial class Fiyat : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fiyat()
        {
            Oda = new HashSet<Oda>();
        }

        public int FiyatTutar { get; set; }

        public int Id { get; set; }

        public int OzellikId { get; set; }

        public int OdaTurId { get; set; }

        public virtual OdaTur OdaTur { get; set; }

        public virtual Ozellik Ozellik { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Oda> Oda { get; set; }
    }
}
