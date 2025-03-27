using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_App.Database.AppDbContextModels;

namespace ToDoList_App.Domain.Features.AddCategory;

public class AddCategoryService
{
    private readonly AppDbContext _db;

    public AddCategoryService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<AddCategoryResponseModel> Insert (AddCategoryRequestModel requestModel)
    {
        AddCategoryResponseModel model = new AddCategoryResponseModel();

        var item = new Category()
        {
           Category_Name = requestModel.Category_Name,
            Description = requestModel.Description,
            Status = "A"
        };

           await _db.Categories.AddAsync(item);

        var result = await _db.SaveChangesAsync();
        string message = result > 0 ? "Category added successfully" : "Failed to add category";

        model.IsSuccess = result > 0;
        model.Message = message;
        model.Data = item;

        return model;

    }
}
