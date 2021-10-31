using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services.Models.Extras;

namespace Services.Models
{
    public class Document: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DocumentId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentType {get; set; }

        public ICollection<DocumentKeyword> DocumentKeywords { get; set; }
        public ICollection<DocumentProperty> DocumentProperties { get; set; }
    }
}