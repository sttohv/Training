using Training.Data.Common;

namespace Training.Data
{
    public sealed class ContactInfoData :BaseData
    {
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }

       // public string UserId { get; set; }  //kas seda on siia vaja v, help!!
    }
}
