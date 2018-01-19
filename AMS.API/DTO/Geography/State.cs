using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Geography
{
    public class State
    {
        public Int32 Id { get; set; }

        [StringLength(250)]
        [Required]
        public string Name { get; set; }
    }
}