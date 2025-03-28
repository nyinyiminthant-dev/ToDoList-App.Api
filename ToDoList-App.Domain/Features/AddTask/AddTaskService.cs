using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList_App.Database.AppDbContextModels;
using Task = ToDoList_App.Database.AppDbContextModels.Task;

namespace ToDoList_App.Domain.Features.AddTask;

public class AddTaskService
{
    private readonly AppDbContext _db;

    public AddTaskService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<AddTaskResponseModel> InsertTask(AddTaskRequestModel requestModel)
    {
        AddTaskResponseModel model = new AddTaskResponseModel();

        var existingTask = await _db.Tasks.AsNoTracking().FirstOrDefaultAsync(x => x.TaskName == requestModel.TaskName);

        if (existingTask != null)
        {
            model.IsSuccess = false;
            model.Message = "Task already exists";
            return model;
        }

        var c_id = await _db.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == requestModel.C_Id);

        if (c_id is null)
        {
            model.IsSuccess = false;
            model.Message = "Category not found";
            return model;
        }

        var item = new Task
        {
            TaskName = requestModel.TaskName,
            dateTime = requestModel.dateTime,
            Status = "A",
            Priority = requestModel.Priority,
            C_Id = requestModel.C_Id

        };

        await _db.Tasks.AddAsync(item);
        var result = await _db.SaveChangesAsync();

        string message = result > 0 ? "Task Added" : "Task not Added";
        model.Message = message;
        model.IsSuccess = result > 0;
        

        return model;
    }
}
