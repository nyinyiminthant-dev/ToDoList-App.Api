using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList_App.Domain.Features.UserRegister;

[Route("api/UserRegister")]
[ApiController]
public class UserRegisterController : ControllerBase
{
    private readonly UserRegisterService _service;

    public UserRegisterController(UserRegisterService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserReigsterRequestModel requestModel)
    {

        try
        {
            UserRegisterResponseModel model = new UserRegisterResponseModel();
            var response = await _service.Register(requestModel);
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

    [HttpPost("Verify-OTP")]
    public async Task<IActionResult> VerifyOTP(string email, string otp)
    {
        try
        {
            UserRegisterResponseModel model = new UserRegisterResponseModel();
            var response = await _service.VerifyOTP( email, otp);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            model.IsSuccess = true;
            model.Message = response.Message;
          
            return Ok(model);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
