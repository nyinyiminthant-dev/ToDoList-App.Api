using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList_App.Domain.Features.AddTask;


[Route("api/AddTask")]
[ApiController]
public class AddTaskController : ControllerBase
{
    private readonly AddTaskService _service;

    public AddTaskController(AddTaskService service)
    {
        _service = service;
    }

    [HttpPost]

    public async Task<IActionResult> AddTask(AddTaskRequestModel requestModel)
    {
        try
        {
            AddTaskResponseModel model = new AddTaskResponseModel();
            var result = await _service.Insert(requestModel);

            if (!result.IsSuccess)
            {
                model.IsSuccess = false;
                model.Message = result.Message;
                return BadRequest(model);
            }

            model.IsSuccess = true;
            model.Message = result.Message;
            model.Data = result.Data;

            return Ok(model);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);

        }
    }
}
