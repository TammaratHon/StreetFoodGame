using System;
using Cysharp.Threading.Tasks;
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

        private Action onCookButtonPressed;

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
            onCookButtonPressed += async () => await HandleCookButtonPressed();
            cookingView.OnCookButtonPressed += onCookButtonPressed;
            cookingView.Show();
            cookingStepView.ShowCookingStep(0);
            cookingStepView.ShowCookingGauge(0).Forget();
        }

        private void HandleIngredientButtonPressed(string ingredientKey)
        {
            if(cookingUseCase.IsIngredientSlotAvailable())
            {
                cookingUseCase.AddIngredient(ingredientKey);
                cookingStepView.ShowIngredient(
                    ingredientKey,
                    spriteProviderService.LoadSprite("Graphics2D/IngredientIcons/Highlight/" + ingredientKey)
                );

                // Show first step when the first ingredient is added
                if (cookingUseCase.GetCurrentIngredientCount() == 1 &&
                    cookingUseCase.CurrentStepIndex == 0    
                )
                {
                    cookingStepView.ShowCookingStep(1);
                }
            }
        }

        private async UniTask HandleCookButtonPressed()
        {
            bool processed = cookingUseCase.ProcessCookingCount();
            bool isCookingCountAtMax = cookingUseCase.IsCookingCountAtMax();

            if(processed)
            {
                cookingView.PlayAvatarCookingAnimation(cookingUseCase.CurrentCookCount);
                await cookingStepView.ShowCookingGauge(cookingUseCase.CurrentCookCount, 0.5f);
            }

            if(isCookingCountAtMax)
            {
                cookingStepView.ShowCookingGauge(0, 0.5f).Forget(); // Reset gauge after processing cook count

                bool stepProcessed = cookingUseCase.ProcessCookingStep(out Menu cookedMenu);
                if(stepProcessed)
                {
                    cookingView.PlayAvatarIdleAnimation();
                    cookingStepView.HideAllIngredients();
                    cookingStepView.ShowCookingStep(
                        cookedMenu == null ?
                        cookingUseCase.CurrentStepIndex + 1 :
                        0
                    );

                    if(cookedMenu != null)
                    {
                        cookingView.ShowCookingResult(
                            spriteProviderService.LoadSprite($"Graphics2D/Menus/{cookedMenu.Name}")
                        );
                    }
                }
            }
        }

        public void ResetCooking()
        {
            cookingUseCase.Reset();
            cookingStepView.HideAllIngredients();
            cookingStepView.ShowCookingStep(0);
            cookingStepView.ShowCookingGauge(0).Forget();
            cookingView.PlayAvatarIdleAnimation();
        }

        public void Dispose()
        {
            cookingView.OnIngredientButtonPressed -= HandleIngredientButtonPressed;
            cookingView.OnCookButtonPressed -= onCookButtonPressed;
        }
    }
}