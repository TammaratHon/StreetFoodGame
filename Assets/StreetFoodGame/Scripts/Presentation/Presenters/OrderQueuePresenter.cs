using System;

using StreetFoodGame.Domain.Entities;
using StreetFoodGame.Domain.Interfaces;

using StreetFoodGame.Application.Interfaces;
using StreetFoodGame.Application.Usecases;
using System.Collections.Generic;

namespace StreetFoodGame.Presentation.Presenters
{
    public class OrderQueuePresenter : IDisposable
    {
        private readonly IOrderQueueView orderQueueView;
        private readonly IOrderQueueRepository orderRepository;
        private readonly ReceiveOrderUseCase receiveOrderUseCase;

        public OrderQueuePresenter(
            IOrderQueueView orderQueueView,
            IOrderQueueRepository orderRepository,
            ReceiveOrderUseCase receiveOrderUseCase
        )
        {
            this.orderQueueView = orderQueueView;
            this.orderRepository = orderRepository;
            this.receiveOrderUseCase = receiveOrderUseCase;
        }

        public void AddOrderToQueue()
        {
            var order = receiveOrderUseCase.CreateOrder();
            orderRepository.EnqueueOrder(order);
            orderQueueView.AddOrder(order.Customer, new List<Recipe> { order.Recipe });
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