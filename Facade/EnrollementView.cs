﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Facade.Common;

namespace Training.Facade
{
    public sealed class EnrollementView:BaseView
    {
        [Display(Name = "Training course")] public string TrainingCourseId { get; set; }
        [Display(Name = "User")] public string UserId { get; set; }
    }
}