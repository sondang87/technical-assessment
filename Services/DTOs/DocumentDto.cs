using System;
using Services.Models.Extras;

namespace Services.DTOs
{
    public class DocumentDto: BaseModelDto
    {
        public Guid DocumentId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentType {get; set; }
    }
}