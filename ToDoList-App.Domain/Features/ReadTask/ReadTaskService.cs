using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList_App.Database.AppDbContextModels;

namespace ToDoList_App.Domain.Features.ReadTask;

public class ReadTaskService
{
    private readonly AppDbContext _db;

    public ReadTaskService (AppDbContext db)
    {
        _db = db;
    }

    public async Task<ReadTaskResponseModel> ReadTasks ()
    {
        ReadTaskResponseModel model = new ReadTaskResponseModel();

        var lst = await _db.Tasks.AsNoTracking().ToListAsync();

        if (lst is null)
        {
            model.IsSuccess = false;
            model.Message = "No Task At All";
            model.Data = null;
            return model;
        }

        model.IsSuccess = true;
        model.Message = "Success";
        model.Data = lst;

        return model;
    }

    public async Task<TaskResponseModel> ReadTaskById (int id)
    {
        TaskResponseModel model  = new TaskResponseModel();
        var task_id = await _db.Tasks.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

        if (task_id is null)
        {
            model.IsSuccess = false;
            model.Message = "Not Found";
            model.Data = null;

            return model;
        }

        model.IsSuccess = true;
        model.Message = "Success";
        model.Data = task_id;

        return model;
       
    }
}
