using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.BatchMaster
{
    public class BatchMaster
    {
        public Int64 Id { get; set; }

        [Required]
        [StringLength(10)]
        public string BatchId { get; set; }

        public string BatchName { get; set; }

        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }

        public Int32 CreatedBy { get; set; }

        [JsonIgnore]
        public DateTime? ModifiedDate { get; set; }

        public Int32 ModifiedBy { get; set; }

        public bool IsActive { get; set; }

        /// <summary>
        /// All other batch details except BatchId and BatchName
        /// </summary>
        public BatchDetail BatchDetails { get; set; }
    }
}