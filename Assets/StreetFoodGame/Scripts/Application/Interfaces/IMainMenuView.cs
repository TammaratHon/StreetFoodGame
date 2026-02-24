using System;

namespace StreetFoodGame.Application.Interfaces
{
    public interface IMainMenuView : IView
    {
        event Action OnStartGameButtonPressed;
        event Action OnOptionsButtonPressed;
        event Action OnExitButtonPressed;
    }
}