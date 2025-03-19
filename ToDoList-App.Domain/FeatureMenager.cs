using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ToDoList_App.Database.AppDbContextModels;

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



        
    }

}
