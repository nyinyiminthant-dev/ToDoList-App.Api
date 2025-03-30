using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList_App.Database.AppDbContextModels;

namespace ToDoList_App.Domain.Features.UpdateTask;

public class UpdateTaskService
{
    private readonly AppDbContext _db;

    public UpdateTaskService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<UpdateTaskResponseModel> UpdateTask(int id, UpdateTaskRequestModel requestModel)
    {
        UpdateTaskResponseModel model = new UpdateTaskResponseModel();

        var task = await _db.Tasks.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

        if (task is null)
        {
            model.IsSuccess = false;
            model.Message = "Not Found";
            
            return model;
        }

        if (!string.IsNullOrEmpty(requestModel.TaskName) && !string.IsNullOrEmpty(requestModel.Priority))
        {
          
            task.TaskName = requestModel.TaskName;
            task.Priority = requestModel.Priority;
        }

        _db.Entry(task).State = EntityState.Modified;
        var result = await _db.SaveChangesAsync();

        string message = result > 0 ? "Success" : "Failed";

       
        model.IsSuccess = result > 0;
        model.Message = message;

        return model;

    }
    }
