using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Assessor
{
    public class AssessorPersonalDetail
    {
        [JsonIgnore]
        public Int64 AssessorId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public char Gender { get; set; }

        public DateTime DOB { get; set; }

        public bool MaritalStatus { get; set; }

        [StringLength(50)]
        public string FatherName { get; set; }

        [StringLength(50)]
        public string MotherName { get; set; }

    }
}