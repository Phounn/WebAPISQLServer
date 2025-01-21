using APIGateWay;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using Data.InitializeDB;

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
Seeding(app);
app.Run();

static void Services(WebApplicationBuilder builder)
{
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ITaskInitializer, TasksInitializer>();
    builder.Services.AddDbContext<ContosoPizzaContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
}

void Seeding(WebApplication app)
{
    using(var scope = app.Services.CreateScope())
    {
        var InitializeCreate = scope.ServiceProvider.GetRequiredService<ITaskInitializer>();
        InitializeCreate.Initialize(scope);
    }

}
