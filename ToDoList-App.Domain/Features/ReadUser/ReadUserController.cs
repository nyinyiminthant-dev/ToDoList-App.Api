using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList_App.Domain.Features.ReadUser;

[Route("api/ReadUser")]
[ApiController]
public class ReadUserController : ControllerBase
{
    private readonly ReadUserService _service;

    public ReadUserController(ReadUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        try
        {
            ReadUserResponseModel model = new ReadUserResponseModel();
            var response = await _service.GetUsers();
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            model.IsSuccess = true;
            model.Message = response.Message;
            model.Data = response.Data;
            return Ok(model);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


    [HttpGet("GetUserByEmail")]

    public async Task<IActionResult> GetUserByEmail(string email)
    {
        try
        {
            UserResponseModel model = new UserResponseModel();
            var response = await _service.GetUserByEmail(email);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            model.IsSuccess = true;
            model.Message = response.Message;
            model.Data = response.Data;
            return Ok(model);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
