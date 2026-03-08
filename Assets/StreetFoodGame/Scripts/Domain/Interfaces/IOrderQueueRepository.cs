using System.Collections.Generic;
using StreetFoodGame.Domain.Entities;

namespace StreetFoodGame.Domain.Interfaces
{
    public interface IOrderQueueRepository
    {
        void EnqueueOrder(Order order);
        Order DequeueOrder();
        void RemoveOrder(Order order);
        int GetQueueSize();
        List<Order> GetCurrentOrders();
    }
}