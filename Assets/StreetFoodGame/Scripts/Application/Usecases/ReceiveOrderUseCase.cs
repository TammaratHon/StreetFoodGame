using StreetFoodGame.Application.Services;
using StreetFoodGame.Domain.Interfaces;
using Utilities;

namespace StreetFoodGame.Application.Usecases
{
    public class ReceiveOrderUseCase
    {
        private readonly IOrderFactory orderFactory;
        private readonly OrderQueueManager orderQueueManager;

        public ReceiveOrderUseCase(
            IOrderFactory orderFactory,
            OrderQueueManager orderQueueManager
        )
        {
            this.orderFactory = orderFactory;
            this.orderQueueManager = orderQueueManager;
        }

        public void CreateOrder()
        {
            orderQueueManager.EnqueueOrder(orderFactory.CreateOrder());
            LogCurrentOrders();
        }

        private void LogCurrentOrders()
        {
            foreach (var o in orderQueueManager.GetCurrentOrders())
            {
                Debugger.Log($"Current order: {o.Recipe.Name} for {o.Customer.Name}");
                for (int i = 0; i < o.Recipe.IngredientsByStep.Count; i++)
                {
                    var step = o.Recipe.IngredientsByStep[i];
                    for (int j = 0; j < step.ingredients.Count; j++)
                    {
                        var ingredient = step.ingredients[j];
                        Debugger.Log($"Step {i + 1}, Ingredient {j + 1}: {ingredient.Name}");
                    }
                }
            }
        }
    }
}