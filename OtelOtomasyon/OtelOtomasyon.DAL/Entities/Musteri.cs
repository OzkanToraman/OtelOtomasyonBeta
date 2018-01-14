namespace OtelOtomasyon.DAL
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Musteri")]
    public partial class Musteri : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Musteri()
        {
            Satis = new HashSet<Satis>();
        }

        [Required]
        [StringLength(50)]
        public string Ad { get; set; }

        [Required]
        [StringLength(50)]
        public string Soyad { get; set; }

        [Required]
        [StringLength(11)]
        public string TCNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime DogumTarihi { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefon { get; set; }

        public int MedeniDurumId { get; set; }

        public int CinsiyetId { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Adres { get; set; }

        [StringLength(10)]
        public string AracPlaka { get; set; }

        public virtual Cinsiyet Cinsiyet { get; set; }

        public virtual MedeniDurum MedeniDurum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Satis> Satis { get; set; }
    }
}
