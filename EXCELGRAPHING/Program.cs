// See https://aka.ms/new-console-template for more information

#region Using Directories




using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EXCELGRAPHING;
using EXCELGRAPHING.Models;
using Microsoft.EntityFrameworkCore;

#endregion




#region Service Creation




// Create a service collection
// This initializes a new instance of ServiceCollection, which is used to register and configure services.
var serviceCollection = new ServiceCollection();

// Configure services
// This method is called to register the necessary services into the service collection.
// It typically includes setting up the DbContext and other dependencies needed by the application.
ConfigureServices(serviceCollection);

// Build the service provider
// This builds the service provider from the service collection, which will resolve and provide the required services.
// The service provider is used to create instances of registered services.
var serviceProvider = serviceCollection.BuildServiceProvider();

// Get the DbContext from the service provider
// This resolves an instance of DBContext from the service provider.
// The DBContext is used to interact with the database using Entity Framework Core.
var context = serviceProvider.GetRequiredService<DBContext>();

#endregion

#region Excel Adding




// Retrieve data from the database
var insuranceCompanies = context.InsuranceCompanies.ToList();
//var providers = context.Providers.ToList();
//var policyholders = context.Policyholders.ToList();
//var bankAccounts = context.BankAccounts.ToList();
//var banks = context.Banks.ToList();


// Create a Format instance to add data to the Excel sheet
var excelFilePath = "/Users/markbowen/Desktop/Applied System Documents/Metrics.xlsx";
var format = new Format(excelFilePath);

// Add data to the Excel sheet
format.AddResultsToSheet(insuranceCompanies);





#endregion


/*
// Example LINQ query
var insuranceCompanies = context.InsuranceCompanies.ToList();

foreach (var company in insuranceCompanies)
{
    Console.WriteLine($"Company: {company.Name}, Email: {company.Email}");
}

*/
#region Databse Operations





void ConfigureServices(IServiceCollection services)
{
    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();

    services.AddDbContext<DBContext>(options =>
        options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 25))));
}

#endregion



//Console.WriteLine("Hello, World!");


/*
var results = new List<Result>
{
    new Result { Id = 1, Value = 100.0, Name = "Mark" }
};

var exporter = new Format("/Users/markbowen/Desktop/Applied System Documents/Metrics.xlsx");
exporter.AddResultsToSheet(results);

Console.WriteLine("Results have been added to sheet");



class Result
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Value { get; set; }
}
*/


/// Create new database table and model add connection extract and transform data