using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList_App.Domain.Features.ReadTaskByCategory;

[Route("api/ReadTaskByCategory")]
[ApiController]
public class ReadTaskByCategoryController : ControllerBase
{
    private readonly ReadTaskByCategoryService _service;

    public ReadTaskByCategoryController (ReadTaskByCategoryService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]

    public async Task<IActionResult> ReadTaskByCategory (int id)
    {
       try
        {

            ReadTaskByCategoryResponseModel model = new ReadTaskByCategoryResponseModel();
            var response = await _service.ReadTaskByCategory(id);

            if (!response.IsSuccess)
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

        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
