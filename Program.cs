using System.Collections.Immutable;
using EfcCodeFirst.Data;
using EfcCodeFirst.Entites;
using Microsoft.EntityFrameworkCore;

namespace EfcCodeFirst;

class Program
{   
    static async Task Main(string[] args)
    {
        using (var context = new AppDbContext())
        {
            var deletedInvoices = await context.Invoices.IgnoreQueryFilters().Where(i => i.IsDeleted)
                                    .OrderBy(i => i.DeleteDate).ToListAsync(); 
            
            foreach (var item in deletedInvoices)
            {
                System.Console.WriteLine($"Item Id {item.Id} | Item Status {item.Status} | Is Delete? {(item.IsDeleted ? "DELETED" : "NOT_DELETED")} | Delete Date {item.DeleteDate}");
            }

            var clients = await context.Clients.IgnoreQueryFilters()
                .Select(c => new
                {
                    Client_Id = c.Id,
                    ClientName = c.Name,
                    ClientProjects = c.Projects
                        .Select(p => new
                        {
                            ProjectTitle = p.Title,
                            ProjectStatus = p.Status,
                            ProjectInvoices = p.Invoices
                                .Select(i => new
                                {
                                    InvoiceAmount = i.MoneyAmount.Amount
                                }).ToList()
                        }).ToList()
                }).ToListAsync();
                System.Console.WriteLine($"Client Id --\tClient Name --\t Project Title --\t Project Status --\t Invoice Amount");
            foreach (var item in clients)
            {
                System.Console.WriteLine($"{item.Client_Id,-15}| {item.ClientName,-15} ");
                foreach (var item2 in item.ClientProjects)
                {
                    System.Console.WriteLine($"{item2.ProjectTitle, 40} {"", -15}| {item2.ProjectStatus} ");
                    foreach (var item3 in item2.ProjectInvoices)
                    {
                        System.Console.WriteLine($"{item3.InvoiceAmount, 90}");
                    }
                } 
            }
            var clientsDemo = await context.Clients.Include(c => c.Projects).ThenInclude(p => p.Invoices).ToListAsync();

            foreach (var client in clientsDemo)
            {
                System.Console.WriteLine("---CLIENT---");
                System.Console.WriteLine(client);
                System.Console.WriteLine("|");
                System.Console.WriteLine("|");
                System.Console.Write("|__");
                foreach (var project in client.Projects)
                {
                    System.Console.WriteLine("\t---PROJECT---");
                    System.Console.WriteLine($"\t{project}");
                    System.Console.WriteLine("\t|");
                    System.Console.WriteLine("\t|");
                    System.Console.Write("\t|__");
                    foreach (var invoice in project.Invoices)
                    {
                        System.Console.WriteLine("\t\t---INVOICE---");
                        System.Console.WriteLine($"\t\t{invoice}");
                    }
                }
            }
        }
    }
}

