using System;
using StreetFoodGame.Application.Interfaces;
using StreetFoodGame.Application.Services;
using StreetFoodGame.Domain.Entities;

namespace StreetFoodGame.Application.Presenters
{
    public class OrderQueuePresenter : IDisposable
    {
        private readonly IOrderQueueView orderQueueView;
        private readonly OrderQueueManager orderQueueManager;

        public OrderQueuePresenter(IOrderQueueView orderQueueView, OrderQueueManager orderQueueManager)
        {
            this.orderQueueView = orderQueueView;
            this.orderQueueManager = orderQueueManager;
        }

        public void AddOrderToQueue(Order order)
        {
            orderQueueManager.EnqueueOrder(order);
            orderQueueView.AddOrder(order.Customer);
        }

        public void RemoveOrderFromQueue(Order order)
        {
            orderQueueManager.RemoveOrder(order);
            orderQueueView.RemoveOrder(order.Customer);
        }

        public void Dispose()
        {
            
        }
    }
}