namespace SimpleStoreFormsApp.EF_Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int OrderId { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
