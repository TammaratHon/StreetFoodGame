using System;

namespace StreetFoodGame.Application.Interfaces
{
    public interface IGameplayView : IView
    {
        event Action OnOptionButtonPressed;
    }
}