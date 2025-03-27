using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_App.Database.AppDbContextModels;

namespace ToDoList_App.Domain.Features.ReadCategory;

public class ReadCategoryService
{

    private readonly AppDbContext _db;

    public ReadCategoryService(AppDbContext db)
    {
        _db = db;
    }

   public async Task<ReadCategoryResponseModel> ReadCategories ()
    {
        ReadCategoryResponseModel model = new ReadCategoryResponseModel();

        var item = _db.Categories.ToList();

        if (item != null)
        {
            model.IsSuccess = true;
            model.Message = "Categories retrieved successfully";
            model.Categories = item;
        }
        else
        {
            model.IsSuccess = false;
            model.Message = "No categories found";
        }

        return model;
    }
}
