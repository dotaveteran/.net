using SchoolService.Models;

namespace SchoolService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using ( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }

        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Shkolas.Any())
            {
                Console.WriteLine("--> Seeding Data");

                context.Shkolas.AddRange(
                  new Shkola() {Name="Sasha", Post="Student", Grade="Excellent"},
                  new Shkola() {Name="Dima", Post="Student", Grade="Excellent"},
                  new Shkola() {Name="George", Post="Student", Grade="Excellent"}
                ); 

                context.SaveChanges();
            }
            else
            {
               Console.WriteLine("--> We already have data");
            }
        }
    }
}