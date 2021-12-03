using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodersLinkProjectWebApp.Models
{
    public class UsrDataModel
    {
        
        public int Id { get; set; }

        [Required (ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]        
        [StringLength(50, MinimumLength =3, ErrorMessage = "First Name must be between 3 and 50 chars.")]
        public string UsrName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 50 chars.")]
        public string UsrLastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Email must be between 6 and 50 chars.")]
        [EmailAddress]
        public string UsrEmail { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime UpdatedTime { get; set; }
    }
}
