using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodersLinkProjectWebApi.Models.Dtos
{
    public class UsrDataCreateDto
    {

        [Required]
        public string UsrName { get; set; }

        [Required]
        public string UsrLastName { get; set; }

        [Required]
        [EmailAddress]
        public string UsrEmail { get; set; }

        public DateTime CreatedTime { get; set; }

    }
}
