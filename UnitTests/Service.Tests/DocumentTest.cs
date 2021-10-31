using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Services;
using Services.Commands;
using Services.DTOs;
using Services.Interfaces;
using Services.Models;
using Services.Models.Extras;
using Xunit;

namespace Service.Tests
{
    public class DocumentTest
    {
        private Mock<IRepositoryBase<Document>> _base;
        private Mock<IMapper> _mapper;
        private IDocumentRepository MockDocumentRepository;
        public readonly IKeywordRepository MockKeywordRepository;

        public DocumentTest()
        {
            IList<DocumentDto> documents = new List<DocumentDto>
            {
                new DocumentDto { DocumentId = Guid.Parse("b8c4d3cc-9659-4a2a-8e00-798e3f491d08"), DocumentName = "Document A", DocumentType = "Promotion", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now },
                new DocumentDto { DocumentId = Guid.Parse("529bdc1a-8e86-4cf3-bfae-1f6be13775f2"), DocumentName = "Document B", DocumentType = "Promotion", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now },
                new DocumentDto { DocumentId = Guid.Parse("882b9cfc-691d-4813-a2f0-78b3d3ec3cfe"), DocumentName = "Document C", DocumentType = "Promotion", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now },
                new DocumentDto { DocumentId = Guid.Parse("ae630703-cbd1-471d-907f-52b757b7eb0e"), DocumentName = "Document D", DocumentType = "Promotion", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now },
                new DocumentDto { DocumentId = Guid.Parse("ea091284-55c7-4c0b-bf0d-ccc4498d41a9"), DocumentName = "Document E", DocumentType = "Promotion", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now },
                new DocumentDto { DocumentId = Guid.Parse("8ed5b22d-2610-4ca4-bba7-91183cc66511"), DocumentName = "Document F", DocumentType = "Promotion", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now },
                new DocumentDto { DocumentId = Guid.Parse("876b6f77-dbea-452e-8638-d04000bd44b1"), DocumentName = "Document G", DocumentType = "Promotion", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now },
                new DocumentDto { DocumentId = Guid.Parse("33b6ffc5-b4e1-4187-95cd-189d33857246"), DocumentName = "Document H", DocumentType = "Promotion", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now },
                new DocumentDto { DocumentId = Guid.Parse("b6e27851-c365-4287-9c58-dea7ee86ee97"), DocumentName = "Document I", DocumentType = "Promotion", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now },
                new DocumentDto { DocumentId = Guid.Parse("2e7c54f2-f773-4e85-b4dd-b3f92f811a2b"), DocumentName = "Document K", DocumentType = "Promotion", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now }
            };

            IList<KeywordDto> keywords = new List<KeywordDto>()
            {
                new KeywordDto { KeywordId = Guid.Parse("3a6ae40c-b4a1-4a50-9d49-3c14682a0889"), Value = "Tablet"},
                new KeywordDto { KeywordId = Guid.Parse("f4e901a1-2269-4df0-8a51-e8b9c4b8a949"), Value = "Laptop"}
            };

            IList<DocumentKeywordDto> docKeys = new List<DocumentKeywordDto>()
            {
                new DocumentKeywordDto(Guid.NewGuid(), 
                                        new DocumentDto { DocumentId = Guid.Parse("b8c4d3cc-9659-4a2a-8e00-798e3f491d08"), DocumentName = "Document A", DocumentType = "Promotion", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now },
                                        new KeywordDto { KeywordId = Guid.Parse("3a6ae40c-b4a1-4a50-9d49-3c14682a0889"), Value = "Tablet"})
            };

            Mock<IDocumentRepository> mockDocRepo = new Mock<IDocumentRepository>();
            mockDocRepo.Setup(m => m.GetAll()).ReturnsAsync(documents);
            mockDocRepo.Setup(m => m.GetDocumentsByKeyword(It.IsAny<string>())).ReturnsAsync((string s) => docKeys.Where(dk => dk.Keyword.Value.Equals(s)).Select(dk => dk.Document).ToList());

            Mock<IKeywordRepository> mockKeywordRepo = new Mock<IKeywordRepository>();
            mockKeywordRepo.Setup(m => m.GetKeyword(It.IsAny<Guid>())).ReturnsAsync((Guid id) => keywords.Where(k => k.KeywordId == id).Single());

            this.MockKeywordRepository = mockKeywordRepo.Object;
            this.MockDocumentRepository = mockDocRepo.Object;
        }

        [Fact]
        public async Task CanReturnKeywordById()
        {
            KeywordDto keywordDto = await this.MockKeywordRepository.GetKeyword(Guid.Parse("3a6ae40c-b4a1-4a50-9d49-3c14682a0889"));
            Assert.NotNull(keywordDto);
            Assert.Matches("Tablet", keywordDto.Value);
        }

        [Fact]
        public async Task FailedReturnDocumentsByKeyword_DueTo_CreatedOn()
        {
            List<DocumentDto> docDtos = this.MockDocumentRepository.GetDocumentsByKeyword("Tablet").Result.ToList();
            Assert.NotNull(docDtos);
            List<DocumentDto> expected = new List<DocumentDto>() {
                new DocumentDto { DocumentId = Guid.Parse("b8c4d3cc-9659-4a2a-8e00-798e3f491d08"), DocumentName = "Document A", DocumentType = "Promotion", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now }
            };
            Assert.Same(expected, docDtos);
        }
    }
}
