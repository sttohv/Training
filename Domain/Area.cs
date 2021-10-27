using System;
using Training.Data;
using Training.Data.Common;
using Training.Domain.Common;
using Training.Domain.Repos;

namespace Training.Domain
{
    public sealed class Area : NamedEntity<AreaData>
    {
        public Area() : this(null) { }

        public Area(AreaData d) : base(d)
        {
            areaBoss = getLazy<User, IUsersRepo>(x => x?.Get(AreaBossId));
        }
        public string AreaBossId => Data?.AreaBossId ?? "Unspecified";

        public User AreaBoss => areaBoss.Value;
        internal Lazy<User> areaBoss { get; }

    }
}
