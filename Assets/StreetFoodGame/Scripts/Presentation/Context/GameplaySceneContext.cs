using UnityEngine;
using StreetFoodGame.Presentation.Views;
using StreetFoodGame.Application.Interfaces;

namespace StreetFoodGame.Presentation.Context
{
    public class GameplaySceneContext : MonoBehaviour
    {
        [SerializeField] private GameplayView gameplayView;
        [SerializeField] private CookingView cookingView;
        [SerializeField] private CookingStepView cookingStepView;
        [SerializeField] private OrderQueueView orderQueueView;

        public IGameplayView GameplayView => gameplayView;
        public ICookingView CookingView => cookingView;
        public ICookingStepView CookingStepView => cookingStepView;
        public IOrderQueueView OrderQueueView => orderQueueView;
    }
}