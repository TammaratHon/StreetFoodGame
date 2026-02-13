using System;

public interface IGameplayView : IView
{
    event Action OnOptionButtonPressed;
}