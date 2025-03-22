using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList_App.Database.AppDbContextModels;

namespace ToDoList_App.Domain.Features.BanUser;

public class BanUserService
{
    private readonly  AppDbContext _db;

    public BanUserService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<BanUserResponseModel> BanUserAsync(string email)
    {
        var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
        if (user == null)
        {
            return new BanUserResponseModel { IsSuccess = false, Message = "User not found" };
        }
        user.Status = "N";
        await _db.SaveChangesAsync();
        return new BanUserResponseModel { IsSuccess = true, Message = "User has been banned" };
    }
}
