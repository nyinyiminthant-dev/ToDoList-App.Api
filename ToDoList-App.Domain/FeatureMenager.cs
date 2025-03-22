using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ToDoList_App.Database.AppDbContextModels;
using ToDoList_App.Domain.Features.AddGoal;
using ToDoList_App.Domain.Features.BanUser;
using ToDoList_App.Domain.Features.ReadUser;
using ToDoList_App.Domain.Features.UserRegister;

namespace ToDoList_App.Domain;

public static class FeatureMenager
{

    public static void AddToDoListFeatures(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
        }, ServiceLifetime.Transient,
        ServiceLifetime.Transient);

        //Please write each services in their services region A Ma May and Ko gye Sit Ning Htoo
        #region Add Services
        builder.Services.AddScoped<UserRegisterService>();
        builder.Services.AddScoped<AddGoalService>();
        #endregion

        #region Read Services
        builder.Services.AddScoped<ReadUserService>();
        #endregion

        #region Update Services
        #endregion

        #region Eidt Services
        #endregion

        #region Delete Services
        #endregion

        #region Deactive Services
        builder.Services.AddScoped<BanUserService>();
        #endregion

    }

}
