using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_App.Database.AppDbContextModels;

namespace ToDoList_App.Domain.Features.DeactiveCategory;

public class DeactiveCategoryService
{
    private readonly AppDbContext _db;

    public DeactiveCategoryService(AppDbContext db)
    {
        _db = db;
    }


}
