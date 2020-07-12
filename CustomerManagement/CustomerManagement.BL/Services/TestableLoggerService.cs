using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.BL.Services
{
    public class TestableLoggerService : ILoggingService
    {
        #region Field

        private readonly ILogger<TestableLoggerService> _logger;

        #endregion

        #region Constructor

        public TestableLoggerService(ILogger<TestableLoggerService> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Method

        /// <summary>
        /// Ghi log 
        /// </summary>
        /// <param name="message">Thông điệp cần log</param>
        /// <param name="parameters">Các thông tin khác cần log nếu có</param>
        /// Created by: TMSANG (03/07/2020)
        public void LogInformation(string message, params object[] parameters)
        {
            _logger.LogInformation(message, parameters);
        }

        #endregion
    }
}
