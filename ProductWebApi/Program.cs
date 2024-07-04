using Microsoft.EntityFrameworkCore;
using ProductWebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// my code
builder.Services.AddDbContext<MyContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("D")));

builder.Services.AddCors(cors => cors.AddPolicy("myPolicy", policy =>
{
    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
}));
// end my code

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

app.UseCors("myPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
