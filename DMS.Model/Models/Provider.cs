using DMS.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMS.Model.Models
{
    [Table("Providers")]
    public class Provider:Infoable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        public string Tags { set; get; }

        public virtual IEnumerable<Product> Products { set; get; }

        public virtual IEnumerable<ProviderTag> ProviderTags { set; get; }
    }
}