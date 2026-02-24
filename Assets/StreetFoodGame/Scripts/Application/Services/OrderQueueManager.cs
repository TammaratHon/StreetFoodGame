using System.Collections.Generic;
using StreetFoodGame.Domain.Entities;

namespace StreetFoodGame.Application.Services
{
    public class OrderQueueManager
    {
        private readonly List<Order> orderQueue = new List<Order>();

        public void EnqueueOrder(Order order)
        {
            orderQueue.Add(order);
        }

        public Order DequeueOrder()
        {
            if (orderQueue.Count == 0)
            {
                return null;
            }

            var order = orderQueue[0];
            orderQueue.RemoveAt(0);
            return order;
        }

        public void RemoveOrder(Order order)
        {
            orderQueue.Remove(order);
        }

        public int GetQueueSize()
        {
            return orderQueue.Count;
        }

        public List<Order> GetCurrentOrders()
        {
            return new List<Order>(orderQueue);
        }
    }
}