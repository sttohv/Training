using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class ContactInfoData :BaseData
    {
        //Kas siia on vaja panna Base Data, sest see igal liikmele nkn erinev
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
    }
}
