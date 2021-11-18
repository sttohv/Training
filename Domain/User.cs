using System;
using System.Collections.Generic;
using Training.Core;
using Training.Data.Common;
using Training.Domain.Common;
using Training.Domain.Repos;

namespace Training.Domain
{   
    public sealed class User : BaseEntity<UserData>
    {
        public User() : this(null) { }
        public User(UserData d) : base(d) { 
            enrollements = getLazy<Enrollement, IEnrollementsRepo>(x => x?.GetByUserId(Id));
            area = getLazy<Area, IAreasRepo>(x => x?.Get(AreaId));
        }


        public string LastName => Data?.LastName ?? "Unspecified";
        public string FirstMidName => Data?.FirstMidName ?? "Unspecified";
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }


        public byte[] Photo => Data?.Photo ?? new List<byte>().ToArray();
        public string AreaId => Data?.AreadId ?? "Unspecified";
        public DateTime EnrollmentDate => Data?.ValidFrom ?? DateTime.MinValue;

        // public ICollection<TrainingCourse> TrainingCourses => Enrollements?.Select(x => x.TrainingCourse).ToList();

        public ICollection<Enrollement> Enrollements => enrollements.Value;
        internal Lazy<ICollection<Enrollement>> enrollements { get; }

        public Area Area => area.Value;
        public Lazy<Area> area { get; }

    }
}
