using BackOfficePOS.Helpers;
using Core.Interfaces;
using Core.Interfaces.GenericInterface;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.Repositories.GenereicRepository;
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
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(MappingProfilescs));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
 app.UseStaticFiles();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("Application-Error"));

app.UseAuthorization();

app.MapControllers();

app.Run();
