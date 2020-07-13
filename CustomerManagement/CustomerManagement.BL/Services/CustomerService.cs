using CustomerManagement.DL.Database;
using CustomerManagement.DL.Repositories;
using CustomerManagement.Entities.DTO;
using CustomerManagement.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.BL.Services
{
    public class CustomerService : ICustomerService
    {
        #region Field

        private readonly ILoggingService _logger;

        #endregion

        #region Property

        public CustomerRepository CustomerRepository { get; set; }

        #endregion

        #region Constructor

        public CustomerService(ILoggingService logger)
        {
            var databaseContext = new SQLiteDatabaseContext("./CustomerManagement.db");
            CustomerRepository = new CustomerRepository(databaseContext);
            _logger = logger;
        }

        #endregion

        #region Method

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Đối tượng khách hàng</param>
        /// <returns>true: Thêm mới thành công, false: Thêm mới thất bại</returns>
        /// Created by: TMSANG (03/07/2020)
        public async Task<Customer> CreateAsync(Customer customer)
        {
            var customerDTO = new CustomerDTO
            {
                FullName = customer.FullName
            };
            var createdCustomer = await CustomerRepository.CreateAsync(customerDTO);
            _logger.LogInformation("Đã thêm một khách hàng mới với Id: {Id}", createdCustomer.Id);
            return MapCustomerDTOToCustomer(createdCustomer);
        }

        /// <summary>
        /// Lấy thông tin của tất cả khách hàng
        /// </summary>
        /// <returns>Danh sách tất cả khách hàng</returns>
        /// Created by: TMSANG (03/07/2020)
        public async Task<List<Customer>> GetAllAsync()
        {
            var customerDTOs = (await CustomerRepository.GetAllAsync()).ToList();
            _logger.LogInformation("Đã get được {Count} khách hàng", customerDTOs.Count);
            return customerDTOs.Select(MapCustomerDTOToCustomer).ToList();
        }

        /// /// <summary>
        /// Lấy thông tin khách hàng theo Id
        /// </summary>
        /// <param name="id">Id của khách hàng</param>
        /// <returns>Thông tin khách hàng theo Id</returns>
        /// Created by: TMSANG (03/07/2020)
        public async Task<Customer> GetByIdAsync(Guid customerId)
        {
            var customer = await CustomerRepository.GetByIdAsync(customerId);

            if (customer == null)
            {
                _logger.LogInformation("Không tìm thấy khách hàng với Id: {Id}", customerId);
                return null;
            }

            _logger.LogInformation("Đã get được một khách hàng với Id: {Id}", customerId);
            return MapCustomerDTOToCustomer(customer);
        }

        /// <summary>
        /// Map đối tượng CustomerDTO sang đối tượng Customer
        /// </summary>
        /// <param name="dto">Đối tượng CustomerDTO</param>
        /// <returns>Đối tượng Customer</returns>
        /// Created by: TMSANG (12/07/2020)
        private Customer MapCustomerDTOToCustomer(CustomerDTO dto)
        {
            return new Customer
            {
                Id = Guid.Parse(dto.Id),
                FullName = dto.FullName
            };
        }

        #endregion
    }
}
