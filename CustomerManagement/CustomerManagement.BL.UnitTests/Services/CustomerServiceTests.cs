using CustomerManagement.BL.Services;
using CustomerManagement.DL.Repositories;
using CustomerManagement.Entities.DTO;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.BL.UnitTests.Services
{
    public class CustomerServiceTests
    {
        private ICustomerService _customerService;
        private ICustomerRepository _customerRepository = Substitute.For<ICustomerRepository>();
        private ILoggingService _logging = Substitute.For<ILoggingService>();

        [Test]
        public async Task GetByIdAsync_WhenCustomerExists_ReturnCustomer()
        {
            // Arrange
            var id = Guid.NewGuid();
            var fullName = "Trần Minh Sáng";
            var customerDTO = new CustomerDTO { Id = id.ToString(), FullName = fullName };
            _customerRepository.GetByIdAsync(id).Returns(customerDTO);
            _customerService = new CustomerService(_customerRepository, _logging);

            // Act
            var customer = await _customerService.GetByIdAsync(id);

            // Assert
            Assert.AreEqual(id, customer.Id);
        }

        [Test]
        public async Task GetByIdAsync_WhenCustomerNotExist_ReturnNull()
        {
            // Arrange
            _customerRepository.GetByIdAsync(Arg.Any<Guid>()).Returns((CustomerDTO)null);
            _customerService = new CustomerService(_customerRepository, _logging);

            // Act
            var customer = await _customerService.GetByIdAsync(Guid.NewGuid());

            // Assert
            Assert.IsNull(customer);
        }

        [Test]
        public async Task GetByIdAsync_WhenCustomerExists_LogAppropriateMessage()
        {
            // Arrange
            var id = Guid.NewGuid();
            var fullName = "Trần Minh Sáng";
            var customerDTO = new CustomerDTO { Id = id.ToString(), FullName = fullName };
            _customerRepository.GetByIdAsync(id).Returns(customerDTO);
            _customerService = new CustomerService(_customerRepository, _logging);

            // Act
            await _customerService.GetByIdAsync(id);

            // Assert
            _logging.Received(1).LogInformation("Đã get được một khách hàng với Id: {Id}", id);
            _logging.DidNotReceive().LogInformation("Không tìm thấy khách hàng với Id: {Id}", id);
        }
    }

    
}
