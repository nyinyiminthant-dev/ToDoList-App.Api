using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ToDoList_App.Database.AppDbContextModels;
using ToDoList_App.Domain.Features.AddCategory;
using ToDoList_App.Domain.Features.AddGoal;
using ToDoList_App.Domain.Features.AddTask;
using ToDoList_App.Domain.Features.BanUser;
using ToDoList_App.Domain.Features.DeactiveCategory;
using ToDoList_App.Domain.Features.DeleteCategory;
using ToDoList_App.Domain.Features.ReadCategory;
using ToDoList_App.Domain.Features.ReadTask;
using ToDoList_App.Domain.Features.ReadTaskByCategory;
using ToDoList_App.Domain.Features.ReadUser;
using ToDoList_App.Domain.Features.UpdateCategory;
using ToDoList_App.Domain.Features.UpdateTask;
using ToDoList_App.Domain.Features.UserLogin;
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
        builder.Services.AddScoped<AddCategoryService>();
        builder.Services.AddScoped<AddTaskService>();
        #endregion

        #region Read Services
        builder.Services.AddScoped<ReadUserService>();
        builder.Services.AddScoped<ReadCategoryService>();
        builder.Services.AddScoped<ReadTaskService>();
        builder.Services.AddScoped<ReadTaskByCategoryService>();
        #endregion

        #region Update Services
        builder.Services.AddScoped<UpdateCategoryService>();
        builder.Services.AddScoped<UpdateTaskService>();
        #endregion

        #region Eidt Services
        #endregion

        #region Delete Services
        builder.Services.AddScoped<DeleteCategoryService>();
        #endregion

        #region Deactive Services
        builder.Services.AddScoped<BanUserService>();
        #endregion

        #region Login Services
        builder.Services.AddScoped<UserLoginService>();
        builder.Services.AddScoped<DeactiveCategoryService>();
        #endregion

    }

}
