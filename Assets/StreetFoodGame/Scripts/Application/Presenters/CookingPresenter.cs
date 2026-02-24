using System.Collections.Generic;
using StreetFoodGame.Application.Interfaces;
using Utilities;

namespace StreetFoodGame.Application.Presenters
{
    public class CookingPresenter
    {
        private readonly ICookingView view;
        private readonly ISpriteProviderService spriteProviderService;

        private HashSet<string> selectedIngredients = new HashSet<string>();

        public CookingPresenter(
            ICookingView view,
            ISpriteProviderService spriteProviderService
        )
        {
            this.view = view;
            this.spriteProviderService = spriteProviderService;

            view.OnIngredientButtonPressed += HandleIngredientButtonPressed;
        }

        public void StartCooking()
        {
            view.Show();
        }

        private void HandleIngredientButtonPressed(string ingredientKey)
        {
            Debugger.Log($"Ingredient button pressed: {ingredientKey}");

            if (selectedIngredients.Contains(ingredientKey))
            {
                Debugger.Log($"Ingredient {ingredientKey} already selected");
                selectedIngredients.Remove(ingredientKey);
                view.HideCookingIngredientImage(ingredientKey);
                return;
            }

            selectedIngredients.Add(ingredientKey);
            view.ShowCookingIngredientImage(
                ingredientKey,
                spriteProviderService.LoadSprite(ingredientKey)
            );

            // Additional logic to handle the ingredient button press can be added here.
        }

        private void Dispose()
        {
            view.OnIngredientButtonPressed -= HandleIngredientButtonPressed;
        }
    }
}