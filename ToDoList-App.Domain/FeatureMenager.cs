using Microsoft.AspNetCore.Builder;

namespace ToDoList_App.Domain;

public static class FeatureMenager
{

    public static void AddToDoListFeatures (this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>();
    }

}
