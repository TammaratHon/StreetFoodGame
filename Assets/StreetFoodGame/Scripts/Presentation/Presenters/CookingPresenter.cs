using System;
using Cysharp.Threading.Tasks;

using StreetFoodGame.Domain.Enums;
using StreetFoodGame.Domain.Entities;

using StreetFoodGame.Application.Interfaces;
using StreetFoodGame.Application.Usecases;

namespace StreetFoodGame.Presentation.Presenters
{
    public class CookingPresenter : IDisposable
    {
        private readonly ICookingView cookingView;
        private readonly ICookingStepView cookingStepView;
        private readonly ISpriteProviderService spriteProviderService;
        private readonly IAudioService audioService;
        private readonly CookingUseCase cookingUseCase;
        private readonly ServeUsecase serveUsecase;

        private Action onCookButtonPressed;
        private bool isCooked;

        public CookingPresenter(
            ICookingView cookingView,
            ICookingStepView cookingStepView,
            ISpriteProviderService spriteProviderService,
            IAudioService audioService,
            CookingUseCase cookingUseCase,
            ServeUsecase serveUsecase
        )
        {
            this.cookingView = cookingView;
            this.cookingStepView = cookingStepView;

            this.spriteProviderService = spriteProviderService;
            this.audioService = audioService;

            this.cookingUseCase = cookingUseCase;
            this.serveUsecase = serveUsecase;
        }

        public void StartCooking()
        {
            isCooked = false;
            cookingView.OnIngredientButtonPressed += HandleIngredientButtonPressed;
            cookingView.OnCompletedIngredientButtonPressed += HandleCompletedIngredientButtonPressed;
            onCookButtonPressed += async () => await HandleCookButtonPressed();
            cookingView.OnCookButtonPressed += onCookButtonPressed;
            cookingView.Show();
            cookingStepView.ShowCookingStep(0);
            cookingStepView.ShowCookingGauge(0).Forget();
        }

        private void HandleIngredientButtonPressed(string ingredientKey)
        {
            if(isCooked) return;
            
            if(cookingUseCase.IsIngredientSlotAvailable())
            {
                audioService.PlayAudio(AudioSourceType.SFX, SoundId.BUTTON_POP);
                
                cookingUseCase.AddIngredient(ingredientKey);
                cookingStepView.ShowCookingIcon(
                    ingredientKey,
                    spriteProviderService.LoadSpriteInSheet("Graphics2D/SpriteSheets/FoodIcon_Spritesheet/", ingredientKey)
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

        private void HandleCompletedIngredientButtonPressed(string ingredientKey)
        {
            if(!isCooked) return;

            if(serveUsecase.IsIngredientSlotAvailable())
            {
                serveUsecase.AddFood(ingredientKey);

                audioService.PlayAudio(AudioSourceType.SFX, SoundId.BUTTON_POP);

                cookingStepView.ShowCookingIcon(
                    ingredientKey,
                    spriteProviderService.LoadSpriteInSheet("Graphics2D/SpriteSheets/FoodIcon_Spritesheet/", ingredientKey)
                );
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
                    cookingStepView.HideAllCookingIcons(
                        () =>
                        {
                            if(cookedMenu != null)
                            {
                                isCooked = true;
                                serveUsecase.AddFood(cookedMenu.Name);
                                cookingStepView.ShowReadyToServeStep();
                                cookingStepView.ShowCookingIcon(
                                    cookedMenu.Name,
                                    spriteProviderService.LoadSpriteInSheet("Graphics2D/SpriteSheets/Somtam_Spritesheet/", cookedMenu.Name)
                                );
                            }
                        }
                    );
                    cookingStepView.ShowCookingStep(
                        cookedMenu == null ?
                        cookingUseCase.CurrentStepIndex + 1 :
                        0
                    );

                }
            }
        }

        public void ResetCooking()
        {
            isCooked = false;
            cookingUseCase.Reset();
            cookingStepView.HideAllCookingIcons();
            cookingStepView.ShowCookingStep(0);
            cookingStepView.ShowCookingGauge(0).Forget();
            cookingView.PlayAvatarIdleAnimation();
        }

        public void Dispose()
        {
            cookingView.OnIngredientButtonPressed -= HandleIngredientButtonPressed;
            cookingView.OnCompletedIngredientButtonPressed -= HandleCompletedIngredientButtonPressed;
            cookingView.OnCookButtonPressed -= onCookButtonPressed;
        }
    }
}