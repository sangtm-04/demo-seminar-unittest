using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Entities.Models
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }
    }
}
