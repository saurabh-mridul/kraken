namespace SelfHost.ConsoleServer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public short QuantityInPackage { get; set; }

        public byte UnitOfMeasurement { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
