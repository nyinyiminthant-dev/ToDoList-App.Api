using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_App.Database.AppDbContextModels;

public class Category
{
    public int Id { get; set; }
    public string Category_Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
}
