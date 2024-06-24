using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarPal.Data;
using CarPal.Models;
using CarPal.Repositories;
using Xunit;

namespace UnitTests
{
    public class CustomerRepositoryTests
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;

        public CustomerRepositoryTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllCustomers()
        {
            // Arrange
            using var context = new ApplicationDbContext(_dbContextOptions);
            context.Customers.AddRange(new List<Customer>
            {
                new Customer { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", DriverLicenseNumber = "12345" },
                new Customer { FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com", DriverLicenseNumber = "67890" }
            });
            await context.SaveChangesAsync();

            var repository = new CustomerRepository(context);

            // Act
            var customers = await repository.GetAllAsync();

            // Assert
            Assert.Equal(2, customers.Count());
        }
    }
}
