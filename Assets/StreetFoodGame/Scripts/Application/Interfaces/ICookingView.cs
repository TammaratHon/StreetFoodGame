using System;

namespace StreetFoodGame.Application.Interfaces
{
    public interface ICookingView : IView
    {
        void PlayAvatarCookingAnimation(int step);
        void PlayAvatarIdleAnimation();

        event Action<string> OnIngredientButtonPressed;
        event Action OnCookButtonPressed;
    }
}