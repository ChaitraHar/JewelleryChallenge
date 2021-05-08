using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelleryShop.Models
{
    public interface ICustomerRepository
    {
        Customer GetById(int Id);
        Customer GetByUserName(string userName);
    }
}
