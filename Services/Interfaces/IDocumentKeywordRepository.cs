using System;
using System.Threading.Tasks;
using Services.DTOs;
using Services.Models;

namespace Services.Interfaces
{
    public interface IDocumentKeywordRepository
    {
        Task<DocumentKeywordDto> AddDocumentKeyword(DocumentDto documentDto, KeywordDto keywordDto, Guid createdBy);
        Task<DocumentKeywordDto> EditDocumentKeyword(DocumentKeywordDto docKey);
        Task<bool> DeleteDocumentKeyword(Guid id);
    }
}