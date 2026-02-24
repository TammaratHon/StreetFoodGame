using System.Collections.Generic;
using StreetFoodGame.Domain.Entities;

namespace StreetFoodGame.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Customer GetCustomerByName(string customerName);
        Customer GetRandomCustomer();
        List<Customer> GetAllCustomers();
    }
}