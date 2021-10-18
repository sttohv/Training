namespace Data
{
    public sealed class ContactInfoData :BaseData
    {
        //Kas siia on vaja panna Base Data, sest see igal liikmele nkn erinev
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
    }
}
