using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRYPT = BCrypt.Net.BCrypt;

namespace JewelleryShop.Models
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly AppDbContext context;
        public CustomerRepository(AppDbContext context)
        {
            this.context = context;
        }
      
        public Customer GetById(int Id)
        {
            return context.Customers.FirstOrDefault(c => c.CustomerId == Id);
        }

        public Customer GetByUserName(string userName)
        {
            return context.Customers.FirstOrDefault(c => c.FirstName == userName);
        }
    }
}
