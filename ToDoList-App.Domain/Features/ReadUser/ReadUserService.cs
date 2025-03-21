using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList_App.Database.AppDbContextModels;

namespace ToDoList_App.Domain.Features.ReadUser;

public class ReadUserService
{
    private readonly AppDbContext _db;

    public ReadUserService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<ReadUserResponseModel> GetUsers()
    {
        ReadUserResponseModel model = new ReadUserResponseModel();
        var users = await _db.Users.AsNoTracking().ToListAsync();
        if (users is null)
        {
            model.IsSuccess = false;
            model.Message = "Users found";
            model.Data = null!;
            return model;

        }
     
        model.IsSuccess = true;
        model.Message = "Success";
        model.Data = users;
        return model;

    }

    public async Task<UserResponseModel> GetUserByEmail (string email) { 

        UserResponseModel model = new UserResponseModel();

        var user = await _db.Users.Where(x => x.Email == email).FirstOrDefaultAsync();

        if (user is null)
        {
            model.IsSuccess = false;
            model.Message = "User not found";
            model.Data = null!;
        }

        model.IsSuccess = true;
        model.Message = "Success";
        model.Data = user!;

        return model;
    }
}
