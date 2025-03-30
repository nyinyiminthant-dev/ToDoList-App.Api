using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_App.Domain.Features.UpdateTask
{
    public class UpdateTaskRequestModel
    {
        public string TaskName { get; set; }
        public string Priority { get; set; }
    }
}
