using System;
using StreetFoodGame.Application.Interfaces;
using StreetFoodGame.Application.Usecases;
using StreetFoodGame.Domain.Entities;

namespace StreetFoodGame.Presentation.Presenters
{
    public class CookingPresenter : IDisposable
    {
        private readonly ICookingView view;
        private readonly ISpriteProviderService spriteProviderService;
        private readonly CookingUseCase cookingUseCase;

        public CookingPresenter(
            ICookingView view,
            ISpriteProviderService spriteProviderService,
            CookingUseCase cookingUseCase
        )
        {
            this.view = view;
            this.spriteProviderService = spriteProviderService;
            this.cookingUseCase = cookingUseCase;
        }

        public void StartCooking()
        {
            view.OnIngredientButtonPressed += HandleIngredientButtonPressed;
            view.OnCookButtonPressed += HandleCookButtonPressed;
            view.Show();
        }

        private void HandleIngredientButtonPressed(string ingredientKey)
        {
            if(cookingUseCase.IsIngredientContained(ingredientKey))
            {
                cookingUseCase.RemoveIngredient(ingredientKey);
                view.HideCookingIngredientImage(ingredientKey);
            }
            else
            {
                cookingUseCase.AddIngredient(ingredientKey);
                view.ShowCookingIngredientImage(
                    ingredientKey,
                    spriteProviderService.LoadSprite(ingredientKey)
                );
            }
        }

        private void HandleCookButtonPressed()
        {
            if(cookingUseCase.Cook(out Menu cookedMenu))
            {
                view.HideAllCookingIngredientImages();
            }
        }

        public void Dispose()
        {
            view.OnIngredientButtonPressed -= HandleIngredientButtonPressed;
            view.OnCookButtonPressed -= HandleCookButtonPressed;
        }
    }
}