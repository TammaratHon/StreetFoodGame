using System;

public interface IMainMenuView : IView
{
    event Action OnStartGameButtonPressed;
    event Action OnOptionsButtonPressed;
    event Action OnExitButtonPressed;
}