using StreetFoodGame.Application.Interfaces;
using StreetFoodGame.Application.Services;
using StreetFoodGame.Domain.Entities;
using StreetFoodGame.Domain.Interfaces;
using Utilities;

namespace StreetFoodGame.Application.Presenters
{
    public class GameplayPresenter
    {
        private readonly IGameplayView view;
        private readonly ISceneService sceneService;

        private readonly IOrderFactory orderFactory;
        private readonly OrderQueueManager orderQueueManager;

        public GameplayPresenter(
            IGameplayView view,
            ISceneService sceneService,
            IOrderFactory orderFactory,
            OrderQueueManager orderQueueManager
        )
        {
            this.view = view;
            this.sceneService = sceneService;
            this.orderFactory = orderFactory;
            this.orderQueueManager = orderQueueManager;

            view.OnOptionButtonPressed += HandleOptionButtonPressed;
        }

        public void StartGameplay()
        {
            CreateInitialOrders();

            // Additional logic to initialize gameplay can be added here.
            view.Show();

            LogCurrentOrders();
        }

        public void EndGameplay()
        {
            sceneService.UnloadScene(
                "Gameplay",
                OnGameplaySceneUnloaded
            );
        }

        private void OnGameplaySceneUnloaded()
        {
            // Additional logic after the gameplay scene is unloaded can be added here.
        }

        private void CreateInitialOrders()
        {
            for (int i = 0; i < 3; i++)
            {
                Order order = orderFactory.CreateOrder();
                orderQueueManager.EnqueueOrder(order);
            }
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

        private void HandleOptionButtonPressed()
        {
            Debugger.Log($"Option button pressed");
            // Additional logic to handle the option button press can be added here.
        }

        private void Dispose()
        {
            view.OnOptionButtonPressed -= HandleOptionButtonPressed;
        }
    }
}
