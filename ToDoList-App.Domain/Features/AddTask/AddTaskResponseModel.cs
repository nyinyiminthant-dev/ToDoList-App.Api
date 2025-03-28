using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_App.Domain.Features.AddTask;

public class AddTaskResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public Task? Data { get; set; }
}
