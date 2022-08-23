using Microsoft.EntityFrameworkCore;
using RestfultAPIProject.Data;
using RestfultAPIProject.Repository;
using RestfultAPIProject.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DatabaseContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DatabaseConnection")
    )
);
builder.Services.AddScoped<IPostService, PostManager>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(EfRepositoryBase<>));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
