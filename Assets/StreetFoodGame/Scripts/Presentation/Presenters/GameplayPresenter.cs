using System;
using VContainer.Unity;

using StreetFoodGame.Domain.Enums;
using StreetFoodGame.Application.Interfaces;
using StreetFoodGame.Application.Usecases;

namespace StreetFoodGame.Presentation.Presenters
{
    public class GameplayPresenter : IStartable, IDisposable
    {
        private readonly IGameplayView view;
        private readonly IApplicationService applicationService;
        private readonly StartGameUseCase startGameUseCase;
        private readonly CookingPresenter cookingPresenter;
        private readonly OrderQueuePresenter orderQueuePresenter;

        public GameplayPresenter(
            IGameplayView view,
            IApplicationService applicationService,
            StartGameUseCase startGameUseCase,
            CookingPresenter cookingPresenter,
            OrderQueuePresenter orderQueuePresenter
        )
        {
            this.view = view;
            this.applicationService = applicationService;
            this.startGameUseCase = startGameUseCase;
            this.cookingPresenter = cookingPresenter;
            this.orderQueuePresenter = orderQueuePresenter;
        }

        public void Start()
        {
            view.OnOptionButtonPressed += HandleOptionButtonPressed;
            startGameUseCase.Execute();

            // Additional logic to initialize gameplay can be added here.
            view.Show();
            cookingPresenter.StartCooking();
        }

        public void EndGameplay()
        {
            applicationService.ChangeState(AppState.MainMenu);
            Dispose();
        }

        private void HandleOptionButtonPressed()
        {
            // Additional logic to handle the option button press can be added here.
        }

        public void Dispose()
        {
            view.OnOptionButtonPressed -= HandleOptionButtonPressed;
        }
    }
}
