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

        public Order CreateOrder(int recipeCount = 1)
        {
            var order = orderFactory.CreateOrder(recipeCount);
            return order;
        }
    }
}