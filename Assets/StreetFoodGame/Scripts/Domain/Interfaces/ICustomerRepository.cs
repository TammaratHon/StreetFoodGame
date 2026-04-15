using System.Collections.Generic;
using StreetFoodGame.Domain.Entities;

namespace StreetFoodGame.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Customer GetCustomerByKey(string customerKey);
        Customer GetRandomCustomer();
        List<Customer> GetAllCustomers();
    }
}