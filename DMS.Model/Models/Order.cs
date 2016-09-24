using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMS.Model.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Tu dong tang ID
        public int ID { set; get; }

        [Required]
        public int CustomerID { set; get; }

        [Required]
        public int OrderCategoryID { set; get; }

        [MaxLength(256)]
        public string CustomerMessage { set; get; }

        public DateTime? CreatedDate { set; get; }

        public string CreatedBy { set; get; }

        [MaxLength(256)]
        public string PaymentMethod { set; get; }

        public string PaymentStatus { set; get; }
        public bool Status { set; get; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { set; get; }

        [ForeignKey("OrderCategoryID")]
        public virtual OrderCategory OrderCategory { set; get; }

        public virtual IEnumerable<OrderDetail> OrderDetails { set; get; }
    }
}