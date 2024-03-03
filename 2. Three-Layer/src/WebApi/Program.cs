using Microsoft.EntityFrameworkCore;
using Repository.Db;
using Repository.DependencyInjection;
using Service.DenpendencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddDbContext<NorthwindContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindDatabase")));

builder.Services.AddRepository();
builder.Services.AddService();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();