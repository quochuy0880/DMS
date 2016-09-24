using DMS.Model.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMS.Model.Models
{
    [Table("Customers")]
    public class Customer : Infoable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        public bool? HotFlag { set; get; }
        public int? ViewCount { set; get; }
    }
}