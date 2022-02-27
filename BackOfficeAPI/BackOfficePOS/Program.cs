using BackOfficePOS.Errors;
using BackOfficePOS.Extensions;
using BackOfficePOS.Helpers;
using BackOfficePOS.Middleware;
using Core.Entities.Identity;
using Core.Interfaces;
using Core.Interfaces.GenericInterface;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.Repositories.GenereicRepository;
using Infrastructure.Identity;
using Infrastructure.Identity.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddApplicationServices();
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<AppIdentityDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));
builder.Services.AddSingleton<IConnectionMultiplexer>(c =>
{
    var configuration = ConfigurationOptions.
    Parse(builder.Configuration.GetConnectionString("Redis"), true);

    return ConnectionMultiplexer.Connect(configuration);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumention();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var loggerFactory = service.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = service.GetRequiredService<DataContext>();
        await context.Database.MigrateAsync();

        var userManager = service.GetRequiredService<UserManager<User>>();
        var identityContext = service.GetRequiredService<AppIdentityDbContext>();
        await identityContext.Database.MigrateAsync();
        await AppIdentityDbContextSeed.SeedUsersAsync(userManager);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An Error Occured during Migrations");
    }
}



// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();
app.UseSwaagerDocumentation();
//if (app.Environment.IsDevelopment()) 
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c=>c.SwaggerEndpoint("/swagger/v1/swagger.jason","Api v1"));
//}
app.UseStatusCodePagesWithReExecute("/error/{0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("Application-Error"));
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
