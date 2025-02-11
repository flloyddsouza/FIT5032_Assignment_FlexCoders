//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlexCoders_Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            DateUpdated = System.DateTime.Now;
            this.Links = new HashSet<Links>();
        }

        public enum DifficultyType
        {
            [Description("Beginners")]
            Beginners,

            [Description("Intermediate")]
            Intermediate,

            [Description("Difficult")]
            Difficult
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Course Name")]
        [Display(Name = "Course Name")]
        [StringLength(60, MinimumLength = 4)]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Enter Course Description")]
        [Display(Name = "Course Description")]
        [StringLength(500, MinimumLength = 10)]
        public string CourseDescription { get; set; }

        [Display(Name = "Date Updated")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime DateUpdated { get; set; }

        [Required(ErrorMessage = "Enter Contributers")]
        [Display(Name = "Contributers")]
        [StringLength(60, MinimumLength = 4)]
        public string Contributers { get; set; }

        [Required(ErrorMessage = "Enter Language")]
        [Display(Name = "Language")]
        [StringLength(60, MinimumLength = 4)]
        public string Language { get; set; }


        [Required(ErrorMessage = "Select Difficulty Level")]
        [Display(Name = "Difficulty Level")]
        public string DifficultyLevel { get; set; }

        [Required(ErrorMessage = "Enter Image URL")]
        [Display(Name = "Image URL")]
        [Url]
        public string ImageURL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Links> Links { get; set; }
    }
}
