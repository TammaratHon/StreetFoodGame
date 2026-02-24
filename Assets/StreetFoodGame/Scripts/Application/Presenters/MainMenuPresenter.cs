using System;
using StreetFoodGame.Application.Interfaces;

namespace StreetFoodGame.Application.Presenters
{
    public class MainMenuPresenter
    {
        private readonly IMainMenuView view;
        private readonly ISceneService sceneService;
        private readonly IApplicationService applicationService;
        private readonly Action onGameStarted;

        public MainMenuPresenter(
            IMainMenuView view,
            ISceneService sceneService,
            IApplicationService applicationService,
            Action onGameStarted
        )
        {
            this.view = view;
            this.sceneService = sceneService;
            this.applicationService = applicationService;
            this.onGameStarted = onGameStarted;

            view.OnStartGameButtonPressed += HandleStartGameButtonPressed;
            view.OnOptionsButtonPressed += HandleOptionsButtonPressed;
            view.OnExitButtonPressed += HandleExitButtonPressed;
        }

        public void Show()
        {
            view.Show();
        }

        private void HandleStartGameButtonPressed()
        {
            view.Hide();
            onGameStarted.Invoke();
        }

        private void HandleOptionsButtonPressed()
        {
            // Implement options menu logic here
        }

        private void HandleExitButtonPressed()
        {
            applicationService.Quit();
        }

        private void Dispose()
        {
            view.OnStartGameButtonPressed -= HandleStartGameButtonPressed;
            view.OnOptionsButtonPressed -= HandleOptionsButtonPressed;
            view.OnExitButtonPressed -= HandleExitButtonPressed;
        }
    }
}