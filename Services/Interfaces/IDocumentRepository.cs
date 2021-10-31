using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.DTOs;

namespace Services.Interfaces
{
    public interface IDocumentRepository
    {
        #region QUERY

        Task<DocumentDto> GetDocument(Guid docId);
        Task<IEnumerable<DocumentDto>> GetAll();
        Task<IEnumerable<DocumentDto>> GetDocumentsByKeyword(string keyword);
        Task<IEnumerable<DocumentDto>> GetSuggestionDocsByKeyword(string keyword);

        #endregion
    }
}