using System;
using StreetFoodGame.Domain.Entities;
using StreetFoodGame.Domain.Interfaces;
using StreetFoodGame.Application.Interfaces;

namespace StreetFoodGame.Presentation.Presenters
{
    public class OrderQueuePresenter : IDisposable
    {
        private readonly IOrderQueueView orderQueueView;
        private readonly IOrderRepository orderRepository;

        public OrderQueuePresenter(IOrderQueueView orderQueueView, IOrderRepository orderRepository)
        {
            this.orderQueueView = orderQueueView;
            this.orderRepository = orderRepository;
        }

        public void AddOrderToQueue(Order order)
        {
            orderRepository.EnqueueOrder(order);
            orderQueueView.AddOrder(order.Customer);
        }

        public void RemoveOrderFromQueue(Order order)
        {
            orderRepository.RemoveOrder(order);
            orderQueueView.RemoveOrder(order.Customer);
        }

        public void Dispose()
        {
            
        }
    }
}