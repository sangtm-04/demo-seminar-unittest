using CustomerManagement.Interfaces;
using CustomerManagement.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        #region Field

        private readonly IDatabaseContext _databaseContext;

        #endregion

        #region Constructor

        public CustomerRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
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
            using var connection = await _databaseContext.CreateConnectionAsync();
            customer.Id = Guid.NewGuid();
            await connection.ExecuteAsync("INSERT INTO Customer(Id, FullName) VALUES (@id, @name)", new { id = customer.Id, name = customer.FullName });
            return customer;
        }

        /// <summary>
        /// Lấy thông tin của tất cả khách hàng
        /// </summary>
        /// <returns>Danh sách tất cả khách hàng</returns>
        /// Created by: TMSANG (03/07/2020)
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            using var connection = await _databaseContext.CreateConnectionAsync();
            return await connection.QueryAsync<Customer>("SELECT * FROM Customer");
        }

        /// <summary>
        /// Lấy thông tin khách hàng theo Id
        /// </summary>
        /// <param name="id">Id của khách hàng</param>
        /// <returns>Thông tin khách hàng theo Id</returns>
        /// Created by: TMSANG (03/07/2020)
        public async Task<Customer> GetByIdAsync(Guid id)
        {
            using var connection = await _databaseContext.CreateConnectionAsync();
            return await connection.QuerySingleOrDefaultAsync<Customer>("SELECT * FROM Customer WHERE Id=@id", new { id = id.ToString() });
        } 

        #endregion
    }
}
