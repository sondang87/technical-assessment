using System;
using System.Collections.Generic;
using System.Linq;
using Services.Models.Extras;

namespace Services.DTOs
{
    public class KeywordDto : BaseModelDto
    {
        public KeywordDto()
        {
            this.DocumentIds = new List<Guid>();
        }

        public KeywordDto(Guid keywordId, string value, List<Guid> documentIds)
        {
            this.KeywordId = keywordId;
            this.Value = value;
            this.DocumentIds = documentIds;
        }

        public Guid KeywordId { get; set; }
        public string Value { get; set; }

        //extra
        public List<Guid> DocumentIds { get; set; }
    }
}