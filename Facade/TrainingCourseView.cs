﻿using System;
using System.ComponentModel.DataAnnotations;
using Training.Facade.Common;

namespace Training.Facade
{
    public sealed class TrainingCourseView:NamedView
    {
        public string Title { get; set; }
        [Display(Name = "Area")] public string AreaId { get; set; }
        [Range(0, 100)] public int MaxPeopleInTraining { get; set; }
        
        [DisplayFormat(DataFormatString = "{dd / MMM / yyyy HH: mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Date")] public DateTime? CourseTime { get; set; }

    }
}