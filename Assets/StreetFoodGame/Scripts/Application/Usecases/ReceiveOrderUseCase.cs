using StreetFoodGame.Domain.Interfaces;

namespace StreetFoodGame.Application.Usecases
{
    public class ReceiveOrderUseCase
    {
        private readonly IOrderFactory orderFactory;
        private readonly IOrderRepository orderRepository;

        public ReceiveOrderUseCase(
            IOrderFactory orderFactory,
            IOrderRepository orderRepository
        )
        {
            this.orderFactory = orderFactory;
            this.orderRepository = orderRepository;
        }

        public void CreateOrder()
        {
            orderRepository.EnqueueOrder(orderFactory.CreateOrder());
            LogCurrentOrders();
        }

        private void LogCurrentOrders()
        {
            foreach (var o in orderRepository.GetCurrentOrders())
            {
                for (int i = 0; i < o.Recipe.IngredientsByStep.Count; i++)
                {
                    var step = o.Recipe.IngredientsByStep[i];
                    for (int j = 0; j < step.ingredients.Count; j++)
                    {
                        var ingredient = step.ingredients[j];
                    }
                }
            }
        }
    }
}