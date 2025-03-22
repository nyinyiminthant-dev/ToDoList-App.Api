using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList_App.Domain.Features.BanUser;

[Route("api/BanUser")]
[ApiController]
public class BanUserController : ControllerBase
{
    private readonly BanUserService _service;

    public BanUserController(BanUserService service)
    {
        _service = service;
    }

    [HttpPatch]
    public async Task<IActionResult> BanUserAsync(string email)
    {
      try
        {
            var result = await _service.BanUserAsync(email);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
