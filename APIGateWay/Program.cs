using APIGateWay;
using Data.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container
Services(builder);

var app = builder.Build();
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Seed();

app.Run();

static void Services(WebApplicationBuilder builder)
{
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();
    builder.Services.AddDbContext<ContosoPizzaContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
}
