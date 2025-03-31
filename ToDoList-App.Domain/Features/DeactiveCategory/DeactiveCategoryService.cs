using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList_App.Database.AppDbContextModels;

namespace ToDoList_App.Domain.Features.DeactiveCategory;

public class DeactiveCategoryService
{
    private readonly AppDbContext _db;

    public DeactiveCategoryService(AppDbContext db)
    {
        _db = db;
    }


    public async Task<DeactiveCategoryResponseModel> DeactiveCategory (int id)
    {
        DeactiveCategoryResponseModel model = new DeactiveCategoryResponseModel();
        var category = await _db.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if(category is null)
        {
            model.IsSuccess = false;
            model.Message = "Category not found";
            return model;
        }

        category.Status = "D";
        _db.Entry(category).State = EntityState.Modified;
        var result = await _db.SaveChangesAsync();

        string message = result > 0 ? "Category deactivated successfully" : "Failed to deactivate category";

        model.IsSuccess = result > 0;
        model.Message = message;
        model.Data = category;

        return model;
    }

}
