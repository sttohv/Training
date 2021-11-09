using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Data;
using Training.Domain;
using Training.Domain.Repos;
using Training.Infra.Common;

namespace Training.Infra
{
    public sealed class EnrollementsRepo : PagedRepo<Enrollement, EnrollementData>, IEnrollementsRepo
    {
        public EnrollementsRepo() : this(null) { }
        public EnrollementsRepo(ApplicationDbContext c) : base(c, c?.Enrollements) { }

        protected internal override Enrollement toEntity(EnrollementData d) => new(d);

        protected internal override EnrollementData toData(Enrollement s) => s?.Data ?? new EnrollementData();

        public List<Enrollement> GetByTrainingCourseId(string id)
             => getRelated(x => x.TrainingCourseId == id);
        

        public List<Enrollement> GetByUserId(string id) 
            => getRelated(x => x.UserId == id);

    }
}
