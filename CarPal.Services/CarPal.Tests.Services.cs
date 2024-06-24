using CarPal.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPal.Services
{
    public class CustomerServiceTests
    {
        [Fact]
        public async Task GetAllAsync_ReturnsAllCustomers()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(GetTestCustomers());
            var service = new CustomerService(mockRepository.Object);

            // Act
            var result = await service.GetAllAsync();

            // Assert
            Assert.Equal(3, result.Count()); // Assuming GetTestCustomers() returns 3 customers
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsCustomerById()
        {
            // Arrange
            int customerId = 1;
            var mockRepository = new Mock<ICustomerRepository>();
            mockRepository.Setup(repo => repo.GetByIdAsync(customerId)).ReturnsAsync(GetTestCustomers().FirstOrDefault(c => c.CustomerId == customerId));
            var service = new CustomerService(mockRepository.Object);

            // Act
            var result = await service.GetByIdAsync(customerId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customerId, result.CustomerId);
        }

        private IEnumerable<Customer> GetTestCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer { CustomerId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", DriverLicenseNumber = "ABC123" },
                new Customer { CustomerId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", DriverLicenseNumber = "XYZ789" },
                new Customer { CustomerId = 3, FirstName = "Michael", LastName = "Brown", Email = "michael.brown@example.com", DriverLicenseNumber = "DEF456" }
            };
            return customers;
        }
    }
}
