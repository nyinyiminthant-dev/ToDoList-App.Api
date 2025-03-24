using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList_App.Database.AppDbContextModels;

namespace ToDoList_App.Domain.Features.UserLogin;

public class UserLoginService
{
    private readonly AppDbContext _db;

    public UserLoginService(AppDbContext db)
    {
        _db = db;
    }


    public async Task<UserLoginResponseModel> Login(UserLoginRequestModel request)
    {
        UserLoginResponseModel model = new UserLoginResponseModel();
        var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == request.Email && x.Password == request.Password);
        if (user == null)
        {
            model.IsSuccess = false;
            model.Message = "Invalid Email or Password";
        }
        else if (user.Status == "N")
        {
            model.IsSuccess = false;
            model.Message = "User is not active";
        }
        
            model.IsSuccess = true;
            model.Message = "Login Successful";
            return model;
        
    }
}
