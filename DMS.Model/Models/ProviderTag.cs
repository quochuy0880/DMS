using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMS.Model.Models
{
    [Table("ProviderTags")]
    public class ProviderTag
    {
        [Key]
        [Column(Order = 1)]
        public int ProviderID { set; get; }

        [Key]
        [Column(TypeName = "varchar", Order = 2)]
        [MaxLength(50)]
        public string TagID { set; get; }

        [ForeignKey("ProviderID")]
        public virtual Provider Provider { set; get; }

        [ForeignKey("TagID")]
        public virtual Tag Tag { set; get; }
    }
}