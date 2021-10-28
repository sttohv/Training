using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Data;
using Training.Domain.Common;

namespace Training.Domain
{
    public sealed class ContactInfo:BaseEntity<ContactInfoData>
    {
        public ContactInfo() : this(null) { }
        public ContactInfo(ContactInfoData d) : base(d)
        {
            //mingi reference userile
        }

        public string PhoneNumber => Data?.PhoneNumber ?? "Unspecified";
        public string MailAddress => Data?.MailAddress ?? "Unspecified";

    }
}
