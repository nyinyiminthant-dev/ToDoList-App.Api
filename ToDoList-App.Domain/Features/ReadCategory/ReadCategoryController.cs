using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList_App.Domain.Features.ReadCategory;

[Route("api/ReadCategory")]
[ApiController]
public class ReadCategoryController : ControllerBase
{
    private readonly ReadCategoryService _service;

    public ReadCategoryController(ReadCategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> ReadCategories()
    {
        try
        {

            ReadCategoryResponseModel model = new ReadCategoryResponseModel();

            var item = await _service.ReadCategories();

            if (!item.IsSuccess)
            {
                model.IsSuccess = false;
                model.Message = model.Message;
   
            }

            model.IsSuccess = true;
            model.Message = "Success";
            model.Categories = item.Categories;

            return Ok(model);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
