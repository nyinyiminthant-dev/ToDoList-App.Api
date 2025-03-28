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


}
