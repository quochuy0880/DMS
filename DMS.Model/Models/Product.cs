using DMS.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMS.Model.Models
{
    [Table("Products")]
    public class Product : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required]
        [MaxLength(256)]
        public string Alias { set; get; }

        [Required]
        public int CategoryID { set; get; }
        
        [Required]
        public int UnitID { set; get; }

        [Required]
        public int ProviderID { set; get; }

        [Required]
        public string BranchID { set; get; }

        [MaxLength(256)]
        public string InvoiceNo { set; get; }

        [MaxLength(256)]
        public string Image { set; get; }

        [Column(TypeName = "xml")]
        public string MoreImages { set; get; }

        public decimal Price { set; get; }
        public decimal? PromotionPrice { set; get; }
        public int? Warranty { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }
        [MaxLength(256)]
        public string SerialNumber { set; get; }
        public string Content { set; get; }
        public bool? HomeFlag { set; get; }
        public bool? HotFlag { set; get; }
        public int? ViewCount { set; get; }
        public string Tags { set; get; }

        public int Quantity { set; get; }
        public DateTime? ValidDate { set; get; }

        [ForeignKey("CategoryID")]
        public virtual ProductCategory ProductCategory { set; get; }

        [ForeignKey("ProviderID")]
        public virtual Provider Provider { set; get; }

        [ForeignKey("UnitID")]
        public virtual UnitProduct UnitProduct { set; get; }

        //[ForeignKey("BranchID")]
        //public virtual Branch Branch { set; get; }

        public virtual IEnumerable<ProductTag> ProductTags { set; get; }
    }
}