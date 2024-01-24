using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder();

builder.ConfigureServices(services =>
{
   services.AddDbContext<DatabaseContext>(x =>
   {
       x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hwila\source\repos\Assignment-SQL\Infrastructure\Data\AssignmentSQL-CF.mdf;Integrated Security=True;Connect Timeout=30");
   });
});

builder.Build();



//TO-DO: INJECT THE DATABASE STRING CONNECTION WITH DEPENDENCY INJECTION
