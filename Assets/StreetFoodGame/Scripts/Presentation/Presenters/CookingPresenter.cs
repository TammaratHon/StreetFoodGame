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
            if (cookingUseCase.Cook(out Menu cookedMenu))
            {
                cookingStepView.HideAllIngredients();
                if(cookingUseCase.CurrentStepIndex == 0)
                {
                    cookingStepView.ShowCookingStep(0);
                } else
                {
                    cookingStepView.ShowCookingStep(cookingUseCase.CurrentStepIndex + 1);
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