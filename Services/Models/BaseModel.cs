using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Models
{
    public class BaseModel
    {
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsDel { get; set; }
    }
}