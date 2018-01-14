namespace OtelOtomasyon.DAL
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Satis : BaseEntity
    {
        [Column(TypeName = "date")]
        public DateTime SatisTarihi { get; set; }

        public bool SatildiMi { get; set; }

        public int Id { get; set; }

        public int MusteriId { get; set; }

        public int PersonelId { get; set; }

        public int RezervasyonId { get; set; }

        public virtual Musteri Musteri { get; set; }

        public virtual Personel Personel { get; set; }

        public virtual Rezervasyon Rezervasyon { get; set; }
    }
}
