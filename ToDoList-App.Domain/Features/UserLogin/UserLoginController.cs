using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList_App.Domain.Features.UserLogin;

[Route("api/Login")]
[ApiController]
public class UserLoginController : ControllerBase
{
    private readonly UserLoginService _service;
    public UserLoginController(UserLoginService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginRequestModel request)
    {
        try
        {
            UserLoginResponseModel model = new UserLoginResponseModel();
            var result = await _service.Login(request);

            if (!result.IsSuccess)
            {
               model.IsSuccess = false;
                model.Message = result.Message;
                return BadRequest(model);
            }
            model.IsSuccess = true;
            model.Message = result.Message;
            return Ok(model);
        }  
        catch (Exception ex)
        {
           return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
