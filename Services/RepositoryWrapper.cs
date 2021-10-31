using System;
using System.Threading.Tasks;
using Services.Interfaces;
using AutoMapper;
using Services.Commands;

namespace Services
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private IKeywordRepository _keywordRepository;
        private IDocumentRepository _documentRepository;
        private IDocumentKeywordRepository _docKeyRepository;

        public RepositoryWrapper(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> SaveChange()
        {
            return await _context.SaveChangesAsync();
        }

        public IKeywordRepository KeywordRepository
        {
            get
            {
                if(_keywordRepository == null)
                {
                    _keywordRepository = new KeywordRepository(_context, _mapper);
                }

                return _keywordRepository;
            }
        }

        public IDocumentRepository DocumentRepository
        {
            get
            {
                if(_documentRepository == null)
                {
                    _documentRepository = new DocumentRepository(_context, _mapper);
                }

                return _documentRepository;
            }
        }

        public IDocumentKeywordRepository DocumentKeywordRepository
        {
            get
            {
                if(_docKeyRepository == null)
                {
                    _docKeyRepository = new DocumentKeywordRepository(_context, _mapper);
                }

                return _docKeyRepository;
            }
        }
    }
}
