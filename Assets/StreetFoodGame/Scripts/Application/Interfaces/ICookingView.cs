using System;

namespace StreetFoodGame.Application.Interfaces
{
    public interface ICookingView : IView
    {
        event Action<string> OnIngredientButtonPressed;

        void ShowCookingIngredientImage(string ingredientKey, object spriteAsset);
        void HideCookingIngredientImage(string ingredientKey);
    }
}