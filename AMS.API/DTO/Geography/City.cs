using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Geography
{
    public class City
    {
        public Int32 Id { get; set; }

        [Required]
        public Int32 StateId { get; set; }

        public string StateName { get; set; }

        [StringLength(250)]
        [Required]
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}