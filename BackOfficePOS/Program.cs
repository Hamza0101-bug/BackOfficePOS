using BackOfficePOS.Errors;
using BackOfficePOS.Extensions;
using BackOfficePOS.Helpers;
using BackOfficePOS.Middleware;
using Core.Interfaces;
using Core.Interfaces.GenericInterface;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.Repositories.GenereicRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//using(var scope = builder.Services.BuildServiceProvider().CreateScope())
// {
//   var service = scope.ServiceProvider;
//   var loggerFactory = service.GetRequiredService<ILoggerFactory>();   
//   try
//   {
//     var context = service.GetRequiredService<DataContext>();
//     await context.Database.MigrateAsync();
//   }
//   catch(Exception ex)
//   {
//       var logger = loggerFactory.CreateLogger<Program>();
//       logger.LogError(ex, "An Error Occured during Migrations");
//   }
// }
builder.Services.AddApplicationServices();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumention();
var app = builder.Build();

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
app.UseAuthorization();
app.MapControllers();
app.Run();
