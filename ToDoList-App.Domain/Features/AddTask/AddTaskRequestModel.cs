using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_App.Domain.Features.AddTask;

public class AddTaskRequestModel
{
    public string TaskName { get; set; }
    public DateTime dateTime { get; set; }
   
    public string Priority { get; set; }
    public int C_Id { get; set; }
}
