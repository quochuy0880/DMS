using DMS.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Model.Models
{
    [Table("Branchs")]
    public class Branch : Infoable
    {
        [Key]
        [MaxLength(50)]
        public string ID { set; get; }

        //public virtual IEnumerable<Product> Products { set; get; }
    }
}
