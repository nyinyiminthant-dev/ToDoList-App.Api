using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        var item = await _db.Categories.ToListAsync();

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

    public async Task<CategoryResponseModel> ReadCategory (int id)
    {
        CategoryResponseModel model = new CategoryResponseModel();
        var item = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (item is null)
        {
            model.IsSuccess = false;
            model.Message = "Category not found";
            model.Categories = null;
        }

        model.IsSuccess = true;
        model.Message = "Category retrieved successfully";
        model.Categories = item;

        return model;
    }
}
