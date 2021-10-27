using System;
using System.Collections.Generic;


namespace Training.Domain.Repos
{
    public interface IEnrollementsRepo:IRepo<Enrollement>{
        List<Enrollement> GetByTrainingCourseId(string id);
        List<Enrollement> GetByUserId(string id);
    }
}
