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
        private readonly CookingPresenter cookingPresenter;
        private readonly OrderQueuePresenter orderQueuePresenter;
        private readonly CookingUseCase cookingUseCase;

        public GameplayPresenter(
            IGameplayView view,
            IApplicationService applicationService,
            CookingPresenter cookingPresenter,
            OrderQueuePresenter orderQueuePresenter,
            CookingUseCase cookingUseCase
        )
        {
            this.view = view;
            this.applicationService = applicationService;
            this.cookingPresenter = cookingPresenter;
            this.orderQueuePresenter = orderQueuePresenter;
            this.cookingUseCase = cookingUseCase;
        }

        public void Start()
        {
            view.OnSettingButtonPressed += HandleSettingButtonPressed;
            view.OnCleanButtonPressed += HandleCleanButtonPressed;
            view.OnRecipeButtonPressed += HandleRecipeButtonPressed;
            orderQueuePresenter.AddOrderToQueue();

            // Additional logic to initialize gameplay can be added here.
            view.Show();
            cookingPresenter.StartCooking();
        }

        public void EndGameplay()
        {
            applicationService.ChangeState(AppState.MainMenu);
            Dispose();
        }

        private void HandleSettingButtonPressed()
        {
            // Additional logic to handle the setting button press can be added here.
        }

        private void HandleCleanButtonPressed()
        {
            // Additional logic to handle the clean button press can be added here.
            cookingUseCase.Reset();
            cookingPresenter.ResetCooking();
        }

        private void HandleRecipeButtonPressed()
        {
            // Additional logic to handle the recipe button press can be added here.
        }

        public void Dispose()
        {
            view.OnSettingButtonPressed -= HandleSettingButtonPressed;
            view.OnCleanButtonPressed -= HandleCleanButtonPressed;
            view.OnRecipeButtonPressed -= HandleRecipeButtonPressed;
        }
    }
}
