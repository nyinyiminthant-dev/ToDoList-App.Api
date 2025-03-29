using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList_App.Domain.Features.ReadTask;


[Route("api/ReadTask")]
[ApiController]
public class ReadTaskController : ControllerBase
{
    private readonly ReadTaskService _service;

    public ReadTaskController(ReadTaskService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> ReadTasks ()
    {
        try
        {
            ReadTaskResponseModel model = new ReadTaskResponseModel();
            var response = await _service.ReadTasks();

            if (!response.IsSuccess)
            {
                model.IsSuccess = false;
                model.Message = response.Message;
                model.Data = null;

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

    [HttpGet("{id}")]

    public async Task<IActionResult> ReadTaskById (int id)
    {
        try
        {

            TaskResponseModel model = new TaskResponseModel();
            var response = await _service.ReadTaskById(id);

            if (!response.IsSuccess)
            {
                model.IsSuccess = false;
                model.Message = response.Message;
                model.Data = response.Data;

                return BadRequest(model) ;
            }

            model.IsSuccess = true;
            model.Message = response.Message;
            model.Data = response.Data;

            return Ok(model);

        } catch (Exception ex)
        {
            return BadRequest(ex.Message) ;
        }
    }
}
