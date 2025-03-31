using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList_App.Database.AppDbContextModels;

namespace ToDoList_App.Domain.Features.AddGoal;

public class AddGoalService
{
    private readonly AppDbContext _db;

    public AddGoalService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<AddGoalResponseModel> Insert(AddGoalRequestModel requestModel)
    {
        AddGoalResponseModel model = new AddGoalResponseModel();
       var task_id = await _db.Tasks.AsNoTracking().FirstOrDefaultAsync(x => x.Id == requestModel.T_Id);
        if (task_id is null)
        {
            model.IsSuccess = false;
            model.Message = "Task not found";
            return model;
        }
        var item = new Goal
        {
            GoalName = requestModel.GoalName,
            DateTime = DateTime.Now,
            StartDate = requestModel.StartDate,
            EndDate = requestModel.EndDate,
            Duration = (requestModel.EndDate - requestModel.StartDate).Days,
            Status = "start",
            T_Id = requestModel.T_Id
        };
        await _db.Goals.AddAsync(item);
        var result = await _db.SaveChangesAsync();
        string message = result > 0 ? "Goal Added" : "Goal not Added";
        model.Message = message;
        model.IsSuccess = result > 0;
        model.Data = item; 
        return model;

    }
}
