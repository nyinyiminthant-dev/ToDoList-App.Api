using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList_App.Domain.Features.DeactiveCategory;

[Route("api/DeactiveCategory")]
[ApiController]
public class DeactiveCategoryController : ControllerBase
{
    private readonly DeactiveCategoryService _service;

    public DeactiveCategoryController(DeactiveCategoryService service)
    {
        _service = service;
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<DeactiveCategoryResponseModel>> DeactiveCategory(int id)
    {
        try
        {
            DeactiveCategoryResponseModel model = new DeactiveCategoryResponseModel();
            var response = await _service.DeactiveCategory(id);

            if(!response.IsSuccess)
            {
               model.IsSuccess = false;
                model.Message = response.Message;
                model.Data = response.Data;

                return BadRequest(model);
            }

            model.IsSuccess = true;
            model.Message = response.Message;
            model.Data = response.Data;

            return Ok(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
