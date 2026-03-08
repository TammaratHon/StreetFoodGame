using System;

namespace StreetFoodGame.Application.Interfaces
{
    public interface ICookingView : IView
    {
        event Action<string> OnIngredientButtonPressed;
        event Action OnCookButtonPressed;
    }
}