using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_App.Database.AppDbContextModels;

namespace ToDoList_App.Domain.Features.ReadTask;

public class ReadTaskResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public List<Database.AppDbContextModels.Task> Data { get; set; }
}

public class TaskResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public Database.AppDbContextModels.Task Data { get; set; }

}
