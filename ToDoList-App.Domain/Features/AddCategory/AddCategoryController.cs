using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList_App.Domain.Features.AddCategory;


[Route("api/AddCategory")]
[ApiController]
public class AddCategoryController : ControllerBase
{
    private readonly AddCategoryService _service;

    public AddCategoryController(AddCategoryService service)
    {
        _service = service;
    }


    [HttpPost]
    public async Task<IActionResult> AddCategory(AddCategoryRequestModel requestModel)
    {

        try
        {
            AddCategoryResponseModel model = new AddCategoryResponseModel();

            var result = await _service.Insert(requestModel);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            model.IsSuccess = true;
            model.Message = model.Message;
            model.Data =result.Data;



            return Ok(model);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);

        }
    }
}
