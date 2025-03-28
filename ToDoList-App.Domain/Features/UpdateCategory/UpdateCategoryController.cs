using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList_App.Domain.Features.UpdateCategory;


[Route("api/UpdateCategory")]
[ApiController]
public class UpdateCategoryController : ControllerBase
{
    private readonly UpdateCategoryService _service;

    public UpdateCategoryController(UpdateCategoryService service)
    {
        _service = service;
    }

    [HttpPatch("{id}")]

    public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryRequestModel requestModel)
    {
        try
        {
            UpdateCategoryReponseModel model =  new UpdateCategoryReponseModel();

            var item = await _service.UpdateCategory(id, requestModel);
            if (item is null)
            {
                model.IsSuccess = false;
                model.Message = "Category not found";
            }

            model.IsSuccess = true;
            model.Message = "Category Updated";
           

            return Ok(item);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
}
