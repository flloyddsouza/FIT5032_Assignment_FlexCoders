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
    using System.ComponentModel.DataAnnotations;

    public partial class Links
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Video Name")]
        [Display(Name = "Video Name")]
        [StringLength(60, MinimumLength = 4)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Video URL")]
        [Display(Name = "Video URL")]
        [Url]
        public string LinkURL { get; set; }
        public int CourseId { get; set; }
    
        public virtual Course Course { get; set; }
    }
}
