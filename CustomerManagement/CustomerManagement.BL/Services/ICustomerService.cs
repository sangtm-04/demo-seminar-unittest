using CustomerManagement.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.BL.Services
{
    public interface ICustomerService
    {
        /// <summary>
        /// Lấy thông tin của tất cả khách hàng
        /// </summary>
        /// <returns>Danh sách tất cả khách hàng</returns>
        /// Created by: TMSANG (03/07/2020)
        Task<List<Customer>> GetAllAsync();

        /// <summary>
        /// Lấy thông tin khách hàng theo Id
        /// </summary>
        /// <param name="id">Id của khách hàng</param>
        /// <returns>Thông tin khách hàng theo Id</returns>
        /// Created by: TMSANG (03/07/2020)
        Task<Customer> GetByIdAsync(Guid customerId);

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Đối tượng khách hàng</param>
        /// <returns>true: Thêm mới thành công, false: Thêm mới thất bại</returns>
        /// Created by: TMSANG (03/07/2020)
        Task<Customer> CreateAsync(Customer customer);
    }
}
