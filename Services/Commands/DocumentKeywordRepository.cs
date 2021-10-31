using System;
using System.Threading.Tasks;
using AutoMapper;
using Services.DTOs;
using Services.Interfaces;
using Services.Models;

namespace Services.Commands
{
    public class DocumentKeywordRepository : RepositoryBase<DocumentKeyword>, IDocumentKeywordRepository
    {
        public DocumentKeywordRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<DocumentKeywordDto> AddDocumentKeyword(DocumentDto document, KeywordDto keyword, Guid createdBy)
        {
            DocumentKeywordDto docKeyDto = new DocumentKeywordDto(Guid.NewGuid(), document, keyword);
            docKeyDto.CreatedBy = createdBy;
            DocumentKeyword docKey = await base.Create(_mapper.Map<DocumentKeyword>(docKeyDto));

            return docKeyDto;
        }

        public async Task<bool> DeleteDocumentKeyword(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<DocumentKeywordDto> EditDocumentKeyword(DocumentKeywordDto docKey)
        {
            throw new NotImplementedException();
        }
    }
}