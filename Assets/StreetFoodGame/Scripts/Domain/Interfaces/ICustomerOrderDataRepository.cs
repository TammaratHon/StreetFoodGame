using System.Collections.Generic;
using StreetFoodGame.Domain.Entities;

namespace StreetFoodGame.Domain.Interfaces
{
    public interface ICustomerOrderDataRepository
    {
        public List<CustomerOrderData> GetAllCustomerOrders();
        public CustomerOrderData GetCustomerOrderByKey(string key);
    }
}