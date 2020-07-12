using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CustomerManagement.Entities.Models;
using CustomerManagement.Common.Constants;
using CustomerManagement.BL.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CustomerManagement.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        #region Field

        private readonly ICustomerService _customerService;

        #endregion

        #region Constructor

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        #endregion

        #region Method

        /// <summary>
        /// Lấy thông tin của tất cả khách hàng
        /// </summary>
        /// <returns>Danh sách tất cả khách hàng</returns>
        /// Created by: TMSANG (03/07/2020)
        [HttpGet]
        [Route("")]
        public async Task<AjaxResult> GetCustomers()
        {
            var customers = await _customerService.GetAllAsync();
            return new AjaxResult
            {
                Code = (int)HttpStatusCode.OK,
                Success = true,
                Message = Constant.SuccessMessage,
                Data = customers
            };
        }

        /// <summary>
        /// Lấy thông tin khách hàng theo Id
        /// </summary>
        /// <param name="customerId">Id của khách hàng</param>
        /// <returns>Thông tin khách hàng theo Id</returns>
        /// Created by: TMSANG (03/07/2020)
        [HttpGet]
        [Route("{customerId}")]
        public async Task<AjaxResult> GetCustomerById(Guid customerId)
        {
            var customer = await _customerService.GetByIdAsync(customerId);
            
            if (customer == null)
            {
                return new AjaxResult
                {
                    Code = 1001,
                    Success = false,
                    Message = ErrorConstant.NotFoundCustomerMsg
                };
            }

            return new AjaxResult
            {
                Code = (int)HttpStatusCode.OK,
                Success = true,
                Message = Constant.SuccessMessage,
                Data = customer
            };
        }

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Đối tượng khách hàng</param>
        /// <returns>true: Thêm mới thành công, false: Thêm mới thất bại</returns>
        /// Created by: TMSANG (03/07/2020)
        [HttpPost]
        [Route("")]
        public async Task<AjaxResult> CreateCustomer([FromBody] Customer customer)
        {
            var createdCustomer = await _customerService.CreateAsync(customer);

            if (createdCustomer == null)
            {
                return new AjaxResult
                {
                    Code = 1002,
                    Success = false,
                    Message = ErrorConstant.CreateFailMsg
                };
            }

            return new AjaxResult
            {
                Code = (int)HttpStatusCode.OK,
                Success = true,
                Message = Constant.SuccessMessage
            };
        }

        #endregion
    }
}