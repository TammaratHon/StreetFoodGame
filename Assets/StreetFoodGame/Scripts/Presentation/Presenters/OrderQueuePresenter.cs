using System;
using System.Linq;

using StreetFoodGame.Domain.Entities;
using StreetFoodGame.Domain.Interfaces;

using StreetFoodGame.Application.Interfaces;
using StreetFoodGame.Application.Usecases;

namespace StreetFoodGame.Presentation.Presenters
{
    public class OrderQueuePresenter : IDisposable
    {
        private readonly IOrderQueueView orderQueueView;
        private readonly IOrderQueueRepository orderRepository;
        private readonly ReceiveOrderUseCase receiveOrderUseCase;
        private readonly CustomerSentenceGenerateUsecase customerSentenceGenerateUsecase;

        public OrderQueuePresenter(
            IOrderQueueView orderQueueView,
            IOrderQueueRepository orderRepository,
            ReceiveOrderUseCase receiveOrderUseCase,
            CustomerSentenceGenerateUsecase customerSentenceGenerateUsecase
        )
        {
            this.orderQueueView = orderQueueView;
            this.orderRepository = orderRepository;
            this.receiveOrderUseCase = receiveOrderUseCase;
            this.customerSentenceGenerateUsecase = customerSentenceGenerateUsecase;
        }

        public void AddOrderToQueue()
        {
            var order = receiveOrderUseCase.CreateOrder(3);
            orderRepository.EnqueueOrder(order);
            string sentence = customerSentenceGenerateUsecase.GenerateSentence(order.Customer, order.Foods.ToList());
            orderQueueView.AddOrder(order.Customer, sentence);
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