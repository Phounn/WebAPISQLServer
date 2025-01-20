using Data.Data;
using System.Runtime.CompilerServices;
using Data.Models;

namespace APIGateWay
{
    public static class TasksInitializer
    {
        public static WebApplication Seed(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using var context = scope.ServiceProvider.GetRequiredService<ContosoPizzaContext>();
                try
                {
                    context.Database.EnsureCreated();
                    var tasks = context.Products.FirstOrDefault();
                    if (tasks == null)
                    {
                        context.Products.AddRange(new Product {Name="meat", Price=1200});
                        context.SaveChanges();
                    }
                }
                catch (Exception ex) { }
                return app;
            }

        }
    }
}
