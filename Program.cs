using ivanStojk_CRUD_API.Configuration;
using ivanStojk_CRUD_API.Logic;
using ivanStojk_CRUD_API.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IGuestRepository, GuestRepository_SQL>();
builder.Services.AddSingleton<IGuestLogic, GuestLogic>();
builder.Services.Configure<ValidationConfiguration>(builder.Configuration.GetSection("ValidationConfiguration"));
builder.Services.Configure<DBConfiguration>(builder.Configuration.GetSection("Database"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
