using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList_App.Domain.Features.AddGoal;


[Route("api/AddGoal")]
[ApiController]
public class AddGoalController : ControllerBase
{
    private readonly AddGoalService _service;

    public AddGoalController(AddGoalService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> InsertGoal(AddGoalRequestModel requestModel)
    {
        try
        {
            AddGoalResponseModel model = new AddGoalResponseModel();

            var response = await _service.Insert(requestModel);

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
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
