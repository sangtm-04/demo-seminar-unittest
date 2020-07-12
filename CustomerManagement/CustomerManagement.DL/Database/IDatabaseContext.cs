using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.DL.Database
{
    public interface IDatabaseContext
    {
        /// <summary>
        /// Tạo kết nối tới Database
        /// </summary>
        /// <returns></returns>
        /// Created by: TMSANG (03/07/2020)
        Task<IDbConnection> CreateConnectionAsync();

        /// <summary>
        /// Thiết lập Database
        /// </summary>
        /// <returns></returns>
        /// Created by: TMSANG (03/07/2020)
        Task SetupAsync();
    }
}
