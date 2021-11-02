using System;
using System.Collections.Generic;
using Training.Core;
using Training.Data.Common;
using Training.Domain.Repos;

namespace Training.Domain.Common
{
    //public interface IUserEntity : IBaseEntity
    //{
    //    public string LastName { get; }
    //    public string FirstMidName { get; }
    //   public string FullName { get; }
    //}
    //public abstract class User<TData> : BaseEntity<TData>, IUserEntity
    //    where TData : UserData, new()
    
    public sealed class User : BaseEntity<UserData>
    {
        //public sealed class User : BaseEntity<UserData> { 
        //where TData :UserData, new()
        public User() : this(null) { }
        public User(UserData d) : base(d) { 
            enrollements = getLazy<Enrollement, IEnrollementsRepo>(x => x?.GetByUserId(Id));
            //contactInfo = getLazy<ContactInfo, IContactInfosRepo>(x => x?.Get(ContactInfoId));
            area = getLazy<Area, IAreasRepo>(x => x?.Get(AreadId));
        }


        public string LastName => Data?.LastName ?? "Unspecified";
        public string FirstMidName => Data?.FirstMidName ?? "Unspecified";
        // public string ContactInfoId => Data?.ContactInfoId ?? "Unspecified";
        public byte[] Photo => Data?.Photo ?? new List<byte>().ToArray();
        public string AreadId => Data?.AreadId ?? "Unspecified";

        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        public ICollection<Enrollement> Enrollments => enrollements.Value;
        internal Lazy<ICollection<Enrollement>> enrollements { get; }

        public ContactInfo ContactInfo => contactInfo.Value;
        public Lazy<ContactInfo> contactInfo { get; }

        public Area Area => area.Value;
        public Lazy<Area> area { get; }

    }
}
