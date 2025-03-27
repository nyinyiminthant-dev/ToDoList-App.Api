using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_App.Domain.Features.AddCategory;

public class AddCategoryRequestModel
{
    public string Category_Name { get; set; }
    public string Description { get; set; }

}
