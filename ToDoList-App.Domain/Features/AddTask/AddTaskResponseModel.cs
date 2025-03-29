using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoList_App.Database.AppDbContextModels;


namespace ToDoList_App.Domain.Features.AddTask;

public class AddTaskResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public Database.AppDbContextModels.Task Data { get; set; }
}
