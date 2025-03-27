using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_App.Database.AppDbContextModels;

namespace ToDoList_App.Domain.Features.ReadCategory;

public class ReadCategoryResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public List<Category> Categories { get; set; }
}
