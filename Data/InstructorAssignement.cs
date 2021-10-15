using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class InstructorAssignement :BaseData
    {
        public string TrainingCourseId { get; set; }
        public string InstructorId { get; set; }
        public string Location { get; set; } //kas on vaja?
    }
}
