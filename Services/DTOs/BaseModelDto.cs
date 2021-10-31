using System;

namespace Services.DTOs
{
    public class BaseModelDto
    {
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsDel { get; set; }
    }
}