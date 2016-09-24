using System;
using System.ComponentModel.DataAnnotations;

namespace DMS.Model.Abstract
{
    public abstract class Infoable : IInfoable
    {
        [Required]
        [MaxLength(256)]
        public string Name { set; get; }
        [MaxLength(256)]
        public string Represent { set; get; }

        [Required]
        [MaxLength(256)]
        public string Alias { set; get; }

        [Required]
        [MaxLength(256)]
        public string Address { set; get; }

        [Required]
        [MaxLength(256)]
        public string Email { set; get; }

        [Required]
        [MaxLength(50)]
        public string Mobile { set; get; }

        [MaxLength(50)]
        public string Tel { set; get; }

        [MaxLength(50)]
        public string Fax { set; get; }

        [MaxLength(256)]
        public string Image { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

        public DateTime? CreatedDate { set; get; }
        public string CreatedBy { set; get; }
        public bool Status { set; get; }

        [MaxLength(50)]
        public string BankAccount { set; get; }

        [MaxLength(50)]
        public string BankName { set; get; }
    }
}