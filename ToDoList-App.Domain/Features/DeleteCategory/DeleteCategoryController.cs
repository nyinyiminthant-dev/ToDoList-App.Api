using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList_App.Domain.Features.DeleteCategory
{
    [Route("api/DeleteCategory")]
    [ApiController]
    public class DeleteCategoryController : ControllerBase
    {

        private readonly DeleteCategoryService _service;
        public DeleteCategoryController(DeleteCategoryService service)
        {
            _service = service;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                DeleteCategoryResponseModel model = new DeleteCategoryResponseModel();
                var response = await _service.DeleteCategory(id);
                if (!response.IsSuccess)
                {
                    model.IsSuccess = false;
                    model.Message = response.Message;
                   
                    return BadRequest(model);
                }

                model.IsSuccess = true;
                model.Message = response.Message;
                
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
