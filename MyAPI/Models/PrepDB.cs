using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using  Microsoft.Extensions.DependencyInjection;
using MyAPI.Data;
using System.Linq;

namespace MyAPI.Models{
    public static class PrepDB{
        
        public static void PrepPopulation(IApplicationBuilder app){
            using (var serviceScope = app.ApplicationServices.CreateScope()){
                SeedData(serviceScope.ServiceProvider.GetService<CustomerContext>());
            }
        }

        private static void SeedData(CustomerContext? customerContext)
        {
            System.Console.WriteLine("Migrating..");
            customerContext?.Database.Migrate();
            
            if(!customerContext.customers.Any()){
                System.Console.WriteLine("No Data found");

            }
            else {
                System.Console.WriteLine("Data Found!");
            }
        }
    }
}