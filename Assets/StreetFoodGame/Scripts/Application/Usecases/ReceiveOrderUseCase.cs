using StreetFoodGame.Domain.Entities;
using StreetFoodGame.Domain.Interfaces;

namespace StreetFoodGame.Application.Usecases
{
    public class ReceiveOrderUseCase
    {
        private readonly IOrderFactory orderFactory;

        public ReceiveOrderUseCase(
            IOrderFactory orderFactory
        )
        {
            this.orderFactory = orderFactory;
        }

        public Order CreateOrder()
        {
            var order = orderFactory.CreateOrder();
            return order;
        }
    }
}