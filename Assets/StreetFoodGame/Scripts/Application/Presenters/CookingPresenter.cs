using System;
using StreetFoodGame.Application.Interfaces;
using StreetFoodGame.Application.Usecases;
using StreetFoodGame.Domain.Entities;
using Utilities;

namespace StreetFoodGame.Application.Presenters
{
    public class CookingPresenter : IDisposable
    {
        private readonly ICookingView view;
        private readonly ISpriteProviderService spriteProviderService;
        private readonly CookingUseCase cookingUseCase;

        public CookingPresenter(
            ICookingView view,
            ISpriteProviderService spriteProviderService,
            CookingUseCase selectIngredientUseCase
        )
        {
            this.view = view;
            this.spriteProviderService = spriteProviderService;
            this.cookingUseCase = selectIngredientUseCase;

            view.OnIngredientButtonPressed += HandleIngredientButtonPressed;
            view.OnCookButtonPressed += HandleCookButtonPressed;
        }

        public void StartCooking()
        {
            view.Show();
        }

        private void HandleIngredientButtonPressed(string ingredientKey)
        {
            if(cookingUseCase.IsIngredientContained(ingredientKey))
            {
                Debugger.Log($"Ingredient {ingredientKey} deselected");
                cookingUseCase.RemoveIngredient(ingredientKey);
                view.HideCookingIngredientImage(ingredientKey);
            }
            else
            {
                Debugger.Log($"Ingredient {ingredientKey} selected");
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
                if(cookedMenu != null)
                {
                    Debugger.Log($"Cooked {cookedMenu.Name}!");
                }
            } else
            {
                Debugger.Log("Cooking failed. Current ingredients do not match any recipe.");
            }
        }

        public void Dispose()
        {
            view.OnIngredientButtonPressed -= HandleIngredientButtonPressed;
            view.OnCookButtonPressed -= HandleCookButtonPressed;
        }
    }
}