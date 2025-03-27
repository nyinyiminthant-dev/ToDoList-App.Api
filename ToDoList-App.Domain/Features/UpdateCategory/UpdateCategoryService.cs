using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList_App.Database.AppDbContextModels;

namespace ToDoList_App.Domain.Features.UpdateCategory;

public class UpdateCategoryService
{
    private readonly AppDbContext _db;

    public UpdateCategoryService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<UpdateCategoryReponseModel> UpdateCategory(int id,UpdateCategoryRequestModel request)
    {
        UpdateCategoryReponseModel model = new UpdateCategoryReponseModel();
        var item = await _db.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if( item is null)
        {
            model.IsSuccess = false;
            model.Message = "Category not found";
            return model;
        }

        if(!string.IsNullOrEmpty(request.CateogryName))
        {
           item.Category_Name = request.CateogryName;
        }

        _db.Entry(item).State = EntityState.Modified;
       var result =  await _db.SaveChangesAsync();

        string message = result > 0 ? "Category Updated" : "Category not Updated";

        model.IsSuccess = result > 0;
        model.Message = message;
        model.Data = item;

        return model;
    }
}
