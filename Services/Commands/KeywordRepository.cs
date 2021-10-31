using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Services.DTOs;
using Services.Interfaces;
using Services.Models;
using Services.Utils;

namespace Services.Commands
{
    public class KeywordRepository: RepositoryBase<Keyword>, IKeywordRepository
    {
        public KeywordRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<KeywordDto> AddKeyword(string value, IEnumerable<Guid> docIds, Guid createdBy)
        {
            if(!string.IsNullOrEmpty(value))
            {
                Keyword keyword = new Keyword { KeywordId = Guid.NewGuid(), Value = value.Trim() };
                keyword.CreatedBy = createdBy;
                keyword = await base.Create(keyword);

                // Add document mapping
                await this.AddDocumentKeywords(docIds, keyword, createdBy);

                return _mapper.Map<KeywordDto>(keyword);
            }
            else
            {
                throw new Exception(Constants.ERROR_MESSAGE.KEYWORD_VALUE_IS_EMPTY);
            }
        }

        public async Task<bool> DeleteKeyword(Guid id)
        {
            var keyword = await base.Single(k => k.KeywordId == id);
            if(keyword != null)
            {
                // remove document mapping
                var docKeys = await base.Context.DocumentKeywords.Where(dk => dk.Keyword.KeywordId == id).ToListAsync();
                base.Context.DocumentKeywords.RemoveRange(docKeys);

                // and then remove keyword
                base.Delete(keyword);

                int result = await base.Context.SaveChangesAsync();
                if(result > 0)
                {
                    return true;
                }

                return false;
            }
            else
            {
                throw new Exception(Constants.ERROR_MESSAGE.KEYWORD_NOT_EXISTS);
            }
        }

        public async Task<KeywordDto> EditKeyword(Guid id, KeywordDto keywordDto, Guid updatedBy)
        {
            Keyword keyword = await base.Single(k => k.KeywordId == id);
            if(keyword != null)
            {
                if(!keyword.Value.Trim().Equals(keywordDto.Value.Trim()))
                {
                    var isExists = await this.IsKeywordExists(keywordDto.Value);
                    if(isExists)
                    {
                        throw new InvalidKeywordException(Constants.ERROR_MESSAGE.KEYWORD_EXISTS);
                    }

                    keyword.Value = keywordDto.Value.Trim();
                    keyword.UpdatedBy = updatedBy;
                }

                // update document mapping
                var docKeys = await base.Context.DocumentKeywords.Where(dk => dk.Keyword.KeywordId == id).ToListAsync();
                base.Context.DocumentKeywords.RemoveRange(docKeys);

                await this.AddDocumentKeywords(keywordDto.DocumentIds, keyword, updatedBy);

                return _mapper.Map<KeywordDto>(keyword);
            }
            else
            {
                throw new Exception(Constants.ERROR_MESSAGE.KEYWORD_NOT_EXISTS);
            }
        }

        private async Task AddDocumentKeywords(IEnumerable<Guid> docIds, Keyword keyword, Guid createdBy)
        {
            if(docIds != null)
            {
                List<DocumentKeyword> docKeys = new List<DocumentKeyword>();
                foreach(var docId in docIds)
                {
                    var document = await base.Context.Documents.FirstOrDefaultAsync(d => d.DocumentId == docId);
                    if(document != null)
                    {
                        DocumentKeyword docKey = new DocumentKeyword { Id = Guid.NewGuid(), Document = document, Keyword = keyword };
                        docKey.CreatedBy = createdBy;
                        docKeys.Add(docKey);
                    }
                }

                await base.Context.DocumentKeywords.AddRangeAsync(docKeys);
            }
        }

        #region QUERY

        public async Task<KeywordDto> GetKeyword(Guid id)
        {
            var keyword = await base.Single(k => k.KeywordId == id);
            var keywordDto = _mapper.Map<KeywordDto>(keyword);
            keywordDto.DocumentIds = await base.Context.DocumentKeywords.Where(dk => dk.Keyword.KeywordId == id).Select(dk => dk.Document.DocumentId).ToListAsync();
            return keywordDto;
        }

        public async Task<IEnumerable<KeywordDto>> GetAll()
        {
            var keywords = await base.FindAll();
            return _mapper.Map<IEnumerable<KeywordDto>>(keywords);
        }

        public async Task<bool> IsKeywordExists(string keyword)
        {
            var keywords = await base.FindByCondition(k => k.Value.Equals(keyword.Trim()));
            if(keywords.Any())
                return true;
            
            return false;
        }

        #endregion
    }
}