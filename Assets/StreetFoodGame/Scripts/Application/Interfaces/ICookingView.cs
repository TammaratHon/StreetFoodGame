using System;

namespace StreetFoodGame.Application.Interfaces
{
    public interface ICookingView : IView
    {
        void PlayAvatarCookingAnimation(int step);
        void PlayAvatarIdleAnimation();

        void ShowCookingResult(object resultSprite);
        void HideCookingResult();
        
        event Action<string> OnIngredientButtonPressed;
        event Action OnCookButtonPressed;
    }
}