using System;
using StreetFoodGame.Application.Interfaces;
using StreetFoodGame.Application.Usecases;
using StreetFoodGame.Domain.Entities;

namespace StreetFoodGame.Presentation.Presenters
{
    public class CookingPresenter : IDisposable
    {
        private readonly ICookingView cookingView;
        private readonly ICookingStepView cookingStepView;
        private readonly ISpriteProviderService spriteProviderService;
        private readonly CookingUseCase cookingUseCase;

        public CookingPresenter(
            ICookingView cookingView,
            ICookingStepView cookingStepView,
            ISpriteProviderService spriteProviderService,
            CookingUseCase cookingUseCase
        )
        {
            this.cookingView = cookingView;
            this.cookingStepView = cookingStepView;
            this.spriteProviderService = spriteProviderService;
            this.cookingUseCase = cookingUseCase;
        }

        public void StartCooking()
        {
            cookingView.OnIngredientButtonPressed += HandleIngredientButtonPressed;
            cookingView.OnCookButtonPressed += HandleCookButtonPressed;
            cookingView.Show();
            cookingStepView.ShowCookingStep(0);
            cookingStepView.ShowCookingGauge(0);
        }

        private void HandleIngredientButtonPressed(string ingredientKey)
        {
            if (cookingUseCase.IsIngredientContained(ingredientKey))
            {
                cookingUseCase.RemoveIngredient(ingredientKey);
                cookingStepView.HideIngredient(ingredientKey);
                if (cookingUseCase.GetCurrentIngredientCount() == 0 &&
                    cookingUseCase.CurrentStepIndex == 0)
                {
                    cookingStepView.ShowCookingStep(0);
                }

                return;
            }
            
            if (!cookingUseCase.IsIngredientContained(ingredientKey) && cookingUseCase.IsIngredientSlotAvailable())
            {
                cookingUseCase.AddIngredient(ingredientKey);
                cookingStepView.ShowIngredient(
                    ingredientKey,
                    spriteProviderService.LoadSprite(ingredientKey)
                );
                if (cookingUseCase.GetCurrentIngredientCount() == 1 &&
                    cookingUseCase.CurrentStepIndex == 0)
                {
                    cookingStepView.ShowCookingStep(1);
                }
            }
        }

        private void HandleCookButtonPressed()
        {
            bool processed = cookingUseCase.ProcessCookingCount();

            cookingStepView.ShowCookingGauge(cookingUseCase.CurrentCookCount);
            if(processed)
            {
                cookingStepView.ShowCookingGauge(0); // Reset gauge after processing cook count

                bool stepProcessed = cookingUseCase.ProcessCookingStep(out Menu cookedMenu);
                if(stepProcessed)
                {
                    cookingStepView.HideAllIngredients();
                    cookingStepView.ShowCookingStep(
                        cookedMenu == null ?
                        cookingUseCase.CurrentStepIndex + 1 :
                        0
                    );
                    if(cookedMenu != null)
                        UnityEngine.Debug.Log($"Cooked Menu: {cookedMenu.Name}");
                }
            }
        }

        public void Dispose()
        {
            cookingView.OnIngredientButtonPressed -= HandleIngredientButtonPressed;
            cookingView.OnCookButtonPressed -= HandleCookButtonPressed;
        }
    }
}