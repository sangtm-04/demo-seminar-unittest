using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Interfaces
{
    public interface ILoggingService
    {
        /// <summary>
        /// Ghi log 
        /// </summary>
        /// <param name="message">Thông điệp cần log</param>
        /// <param name="parameters">Các tham số truyền vào message nếu có</param>
        /// Created by: TMSANG (03/07/2020)
        void LogInformation(string message, params object[] parameters);
    }
}
