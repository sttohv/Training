using System;
using System.ComponentModel.DataAnnotations;
using Training.Facade.Common;

namespace Training.Facade
{
    public sealed class TrainingCourseView:BaseView
    {
        //nimi on juba olemas named view-s
        public string Title { get; set; }
        [Display(Name = "Area")] public string AreaId { get; set; }
        
        [Display(Name = "Area")] public string AreaName { get; set; }

        [Range(0, 100)] public int MaxPeopleInTraining { get; set; }
        
        //järgnev rida teeb kõik katki
        //[DisplayFormat(DataFormatString = "{dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]

        //[DataType(DataType.Date)]
        [Display(Name = "Date")] public DateTime? CourseTime { get; set; }

    }
}
