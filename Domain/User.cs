using System;
using System.Collections.Generic;
using Training.Core;
using Training.Data.Common;
using Training.Domain.Repos;

namespace Training.Domain.Common
{
    public interface IUserEntity : IBaseEntity
    {
        public string LastName { get; }
        public string FirstMidName { get; }
       public string FullName { get; }
    }
    //public abstract class User<TData> : BaseEntity<TData>, IUserEntity
    //    where TData :UserData, new()
    //{
    public sealed class User : BaseEntity<UserData> { 
    //    where TData :UserData, new()
        public User() : this(null) { }
        public User(UserData d) : base(d) 
            => enrollements = getLazy<Enrollement, IEnrollementsRepo>(x => x?.GetByUserId(Id));



        public string LastName => Data?.LastName ?? "Unspecified";
        public string FirstMidName => Data?.FirstMidName ?? "Unspecified";
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }
        public ICollection<Enrollement> Enrollments => enrollements.Value;
        internal Lazy<ICollection<Enrollement>> enrollements { get; }


    }
}
