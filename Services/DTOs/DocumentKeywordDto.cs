using System;

namespace Services.DTOs
{
    public class DocumentKeywordDto: BaseModelDto
    {
        public DocumentKeywordDto(Guid id, DocumentDto document, KeywordDto keyword)
        {
            this.Id = id;
            this.Document = document;
            this.Keyword = keyword;
        }

        public Guid Id { get; set; }
        public DocumentDto Document { get; set; }
        public KeywordDto Keyword { get; set; }
    }
}