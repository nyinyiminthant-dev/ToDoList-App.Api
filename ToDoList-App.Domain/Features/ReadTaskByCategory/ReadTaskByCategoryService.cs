using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList_App.Database.AppDbContextModels;

namespace ToDoList_App.Domain.Features.ReadTaskByCategory;

public class ReadTaskByCategoryService
{
    private readonly AppDbContext _db;

    public ReadTaskByCategoryService (AppDbContext db)
    {
        _db = db;
    }


    public async Task<ReadTaskByCategoryResponseModel> ReadTaskByCategory ( int c_id) 
    {
        ReadTaskByCategoryResponseModel model = new ReadTaskByCategoryResponseModel();

        var task_lst = await _db.Tasks.AsNoTracking().Where(c => c.C_Id == c_id).ToListAsync();
        
        if (task_lst is null)
        {
            model.IsSuccess = false;
            model.Message = "Not Found";
            model.Data = null;

            return model;
        }

        model.IsSuccess = true;
        model.Message = "Success";
        model.Data = task_lst;

        return model;
    }

}
