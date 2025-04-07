using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList_App.Database.AppDbContextModels;

namespace ToDoList_App.Domain.Features.DeleteCategory
{
    public class DeleteCategoryService
    {
        private readonly AppDbContext _db;

        public DeleteCategoryService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<DeleteCategoryResponseModel> DeleteCategory (int id)
        {
            DeleteCategoryResponseModel model = new DeleteCategoryResponseModel();

            var category = await _db.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            if(category == null)
            {
                model.IsSuccess = false;
                model.Message = "Category not found";
                return model;
            }

           _db.Entry(category).State = EntityState.Deleted;

            var result = await _db.SaveChangesAsync();

            string message = result > 0 ? "Success" : "Failed";
            model.IsSuccess = result > 0;
            model.Message = message;
            return model;
        }
    }
}
