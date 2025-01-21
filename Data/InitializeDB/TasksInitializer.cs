using Data.Data;
using System.Runtime.CompilerServices;
using Share.Entities;
using Data.InitializeDB;
using Microsoft.Extensions.DependencyInjection;

namespace Data.InitializeDB
{
    public class TasksInitializer : ITaskInitializer
    {
        
        public void Initialize(IServiceScope scope)
        {
            using var context = scope.ServiceProvider.GetRequiredService<ContosoPizzaContext>();
            try
            {
                context.Database.EnsureCreated();
                var tasks = context.Products.FirstOrDefault();
                if (tasks == null)
                {
                    context.Products.AddRange(new Product { Name = "meat", Price = 1200 });
                    context.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }
    }
}
