using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.DTOs;

namespace Services.Interfaces
{
    public interface IKeywordRepository
    {
        Task<KeywordDto> AddKeyword(string value, IEnumerable<Guid> docIds, Guid createdBy);
        Task<KeywordDto> EditKeyword(Guid id, KeywordDto keywordDto, Guid updatedBy);
        Task<bool> DeleteKeyword(Guid id);

        #region QUERY
        Task<KeywordDto> GetKeyword(Guid id);
        Task<IEnumerable<KeywordDto>> GetAll();
        Task<bool> IsKeywordExists(string keyword);
        #endregion
    }
}