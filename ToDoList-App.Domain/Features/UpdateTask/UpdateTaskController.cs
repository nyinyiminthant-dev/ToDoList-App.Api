using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList_App.Domain.Features.UpdateTask;


[Route("api/UpdateTask")]
[ApiController]
public class UpdateTaskController : ControllerBase
{
    private readonly UpdateTaskService _service;

    public UpdateTaskController(UpdateTaskService service)
    {
        _service = service;
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateTask(int id, UpdateTaskRequestModel requestModel)
    {
        try
        {
            UpdateTaskResponseModel model = new UpdateTaskResponseModel();

            var response = await _service.UpdateTask(id, requestModel);

            if (!response.IsSuccess)
            {
                model.IsSuccess = false;
                model.Message = response.Message;

                return BadRequest(model);
            }

            model.IsSuccess = true;
            model.Message = response.Message;

            return Ok(model);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
