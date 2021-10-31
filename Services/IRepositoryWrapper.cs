using System;
using System.Threading.Tasks;
using Services.Interfaces;

namespace Services
{
    public interface IRepositoryWrapper
    {
        Task<int> SaveChange();
        IUserRepository UserRepository { get; }
        IKeywordRepository KeywordRepository { get; }
        IDocumentRepository DocumentRepository { get; }
        IDocumentKeywordRepository DocumentKeywordRepository { get; }
    }
}
