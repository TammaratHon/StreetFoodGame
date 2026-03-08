using System;
using VContainer.Unity;
using StreetFoodGame.Domain.Enums;
using StreetFoodGame.Application.Interfaces;
using UnityEngine;

namespace StreetFoodGame.Presentation.Presenters
{
    public class MainMenuPresenter : IStartable, IDisposable
    {
        private readonly IMainMenuView view;
        private readonly IApplicationService applicationService;

        public MainMenuPresenter(
            IMainMenuView view,
            IApplicationService applicationService
        )
        {
            this.view = view;
            this.applicationService = applicationService;
        }

        public void Start()
        {
            view.OnStartGameButtonPressed += HandleStartGameButtonPressed;
            view.OnOptionsButtonPressed += HandleOptionsButtonPressed;
            view.OnExitButtonPressed += HandleExitButtonPressed;
            view.Show();
        }

        private void HandleStartGameButtonPressed()
        {
            applicationService.ChangeState(AppState.Gameplay);
        }

        private void HandleOptionsButtonPressed()
        {
            // Implement options menu logic here
        }

        private void HandleExitButtonPressed()
        {
            applicationService.Quit();
        }

        public void Dispose()
        {
            view.OnStartGameButtonPressed -= HandleStartGameButtonPressed;
            view.OnOptionsButtonPressed -= HandleOptionsButtonPressed;
            view.OnExitButtonPressed -= HandleExitButtonPressed;
        }
    }
}