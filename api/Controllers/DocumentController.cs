using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController: BaseController
    {
        private readonly IRepositoryWrapper _repoWrapper;
        public DocumentController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpGet("getSuggested/{keyword}")]
        public async Task<IActionResult> GetSuggestionDocs(string keyword)
        {
            return Ok(await _repoWrapper.DocumentRepository.GetSuggestionDocsByKeyword(keyword));
        }

        [HttpGet("getByKeyword/{keyword}")]
        public async Task<IActionResult> GetByKeyword(string keyword)
        {
            var docs = await _repoWrapper.DocumentRepository.GetDocumentsByKeyword(keyword);
            return Ok(docs);
        }
    }
}