using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            :base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connstring = GetConnectionString().GetAwaiter().GetResult();

            optionsBuilder.UseSqlServer(connstring);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id=1,Name="James",Email="james@gmail.com",Designation="Associate"},
                new Employee { Id=2,Name="Malcolm",Email="malcolm@gmail.com",Designation="Software Engineer"}
                );
        }

        private async Task<string> GetConnectionString()
        {
            AzureServiceTokenProvider azureServiceTokenProvider =
              new AzureServiceTokenProvider();

            KeyVaultClient keyVaultClient =
            new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));

            var secret = await keyVaultClient
                .GetSecretAsync("https://assign2vault.vault.azure.net/secrets/sqlconnectionstr/fd5a5fe7d0be4fac964baeac3bba9299")
                        .ConfigureAwait(false);

            return secret.Value;
        }
    }
}
