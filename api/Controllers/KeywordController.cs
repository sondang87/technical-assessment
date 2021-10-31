using System;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTOs;
using Services.Utils;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KeywordController: BaseController
    {
        private readonly IRepositoryWrapper _repoWrapper;
        public KeywordController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddKeyword(KeywordDto model)
        {
            GetUserIdentity();
            try
            {
                ResponseModel response = null;
                if(model != null && !string.IsNullOrEmpty(model.Value))
                {
                    var isExists = await _repoWrapper.KeywordRepository.IsKeywordExists(model.Value);
                    if(isExists)
                    {
                        response = new ResponseModel() { Code = 400, Message = Constants.ERROR_MESSAGE.KEYWORD_EXISTS };
                        return Ok(response);
                    }

                    var keywordDto = await _repoWrapper.KeywordRepository.AddKeyword(model.Value, model.DocumentIds, Guid.Parse(UserID));
                    await _repoWrapper.SaveChange();

                    response = new ResponseModel() { Code = 200, Message = Constants.SUCCESS_MESSAGE.ADD_KEYWORD_SUCCESS };
                }
                else
                {
                    response = new ResponseModel() { Code = 400, Message = Constants.ERROR_MESSAGE.KEYWORD_VALUE_IS_EMPTY };
                }

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _repoWrapper.KeywordRepository.GetKeyword(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repoWrapper.KeywordRepository.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                bool result = await _repoWrapper.KeywordRepository.DeleteKeyword(id);
                if(result)
                {
                    return Ok(new ResponseModel { Code = 200, Message = Constants.SUCCESS_MESSAGE.DELETE_KEYWORD_SUCCESS });
                }
                else
                {
                    return Ok(new ResponseModel { Code = 500, Message = Constants.ERROR_MESSAGE.COMMON_ERROR });
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, KeywordDto keywordDto)
        {
            GetUserIdentity();
            try
            {
                await _repoWrapper.KeywordRepository.EditKeyword(id, keywordDto, Guid.Parse(UserID));
                int result = await _repoWrapper.SaveChange();
                if(result > 0)
                {
                    return Ok(new ResponseModel { Code = 200, Message = Constants.SUCCESS_MESSAGE.EDIT_KEYWORD_SUCCESS });
                }

                return Ok(new ResponseModel { Code = 500, Message = Constants.ERROR_MESSAGE.COMMON_ERROR });
            }
            catch(InvalidKeywordException ex)
            {
                return Ok(new ResponseModel { Code = 400, Message = ex.Message });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}