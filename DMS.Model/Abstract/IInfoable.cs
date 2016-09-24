using System;

namespace DMS.Model.Abstract
{
    public interface IInfoable
    {
        string Name { set; get; }

        string Represent { set; get; }

        string Alias { set; get; }

        string Address { set; get; }

        string Email { set; get; }

        string Mobile { set; get; }

        string Tel { set; get; }

        string Fax { set; get; }

        string Image { set; get; }

        string Description { set; get; }

        DateTime? CreatedDate { set; get; }
        string CreatedBy { set; get; }
        bool Status { set; get; }

        string BankAccount { set; get; }

        string BankName { set; get; }
    }
}