using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JewelleryShop.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public bool isPrivilaged { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
