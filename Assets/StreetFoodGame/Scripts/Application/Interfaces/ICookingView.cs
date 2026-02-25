using System;

namespace StreetFoodGame.Application.Interfaces
{
    public interface ICookingView : IView
    {
        event Action<string> OnIngredientButtonPressed;
        event Action OnCookButtonPressed;

        void ShowCookingIngredientImage(string ingredientKey, object spriteAsset);
        void HideCookingIngredientImage(string ingredientKey);
        void HideAllCookingIngredientImages();
    }
}