using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Services.DTOs;
using Services.Interfaces;
using Services.Models;

namespace Services.Commands
{
    public class DocumentRepository : RepositoryBase<Document>, IDocumentRepository
    {
        public DocumentRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<DocumentDto>> GetAll()
        {
            var docs = await base.FindAll();

            return _mapper.Map<IEnumerable<DocumentDto>>(docs);
        }

        public async Task<DocumentDto> GetDocument(Guid docId)
        {
            var doc = await base.Single(d => d.DocumentId == docId);

            return _mapper.Map<DocumentDto>(doc);
        }

        public async Task<IEnumerable<DocumentDto>> GetDocumentsByKeyword(string keyword)
        {
            var documents = await base.Context.DocumentKeywords
                                        .Where(dk => dk.Keyword.Value.Equals(keyword.Trim()))
                                        .Include(dk => dk.Document).Select(dk => dk.Document).ToListAsync();
            return _mapper.Map<IEnumerable<DocumentDto>>(documents);
        }

        public async Task<IEnumerable<DocumentDto>> GetSuggestionDocsByKeyword(string keyword)
        {
            var documents = await base.Context.DocumentProperties
                                        .Where(dk => dk.Document.DocumentName.Contains(keyword.Trim()) 
                                        || dk.Product.Contains(keyword) || dk.Supplier.Contains(keyword))
                                        .Include(dk => dk.Document).Select(dk => dk.Document).ToListAsync();
            return _mapper.Map<IEnumerable<DocumentDto>>(documents);
        }
    }
}