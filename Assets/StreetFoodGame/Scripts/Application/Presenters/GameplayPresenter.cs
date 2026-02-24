using System;
using StreetFoodGame.Application.Interfaces;
using StreetFoodGame.Application.Usecases;
using Utilities;

namespace StreetFoodGame.Application.Presenters
{
    public class GameplayPresenter : IDisposable
    {
        private readonly IGameplayView view;
        private readonly ISceneService sceneService;
        private readonly StartGameUseCase startGameUseCase;

        public GameplayPresenter(
            IGameplayView view,
            ISceneService sceneService,
            StartGameUseCase startGameUseCase
        )
        {
            this.view = view;
            this.sceneService = sceneService;
            this.startGameUseCase = startGameUseCase;

            view.OnOptionButtonPressed += HandleOptionButtonPressed;
        }

        public void StartGameplay()
        {
            startGameUseCase.Execute();

            // Additional logic to initialize gameplay can be added here.
            view.Show();
        }

        public void EndGameplay()
        {
            sceneService.UnloadScene(
                "Gameplay",
                OnGameplaySceneUnloaded
            );
        }

        private void OnGameplaySceneUnloaded()
        {
            Dispose();
            // Additional logic after the gameplay scene is unloaded can be added here.
        }

        private void HandleOptionButtonPressed()
        {
            Debugger.Log($"Option button pressed");
            // Additional logic to handle the option button press can be added here.
        }

        public void Dispose()
        {
            view.OnOptionButtonPressed -= HandleOptionButtonPressed;
        }
    }
}
