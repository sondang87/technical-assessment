using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Models
{
    public class Keyword: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid KeywordId { get; set; }
        public string Value { get; set; }

        public ICollection<DocumentKeyword> DocumentKeywords { get; set; }
    }
}