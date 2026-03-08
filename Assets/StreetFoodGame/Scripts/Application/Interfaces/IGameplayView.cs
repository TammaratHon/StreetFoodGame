using System;

namespace StreetFoodGame.Application.Interfaces
{
    public interface IGameplayView : IView
    {
        event Action OnSettingButtonPressed;
        event Action OnCleanButtonPressed;
        event Action OnRecipeButtonPressed;
    }
}