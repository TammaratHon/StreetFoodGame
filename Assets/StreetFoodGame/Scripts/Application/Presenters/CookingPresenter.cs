using StreetFoodGame.Application.Interfaces;
using StreetFoodGame.Application.Usecases;
using Utilities;

namespace StreetFoodGame.Application.Presenters
{
    public class CookingPresenter
    {
        private readonly ICookingView view;
        private readonly ISpriteProviderService spriteProviderService;
        private readonly SelectIngredientUseCase selectIngredientUseCase;

        public CookingPresenter(
            ICookingView view,
            ISpriteProviderService spriteProviderService,
            SelectIngredientUseCase selectIngredientUseCase
        )
        {
            this.view = view;
            this.spriteProviderService = spriteProviderService;
            this.selectIngredientUseCase = selectIngredientUseCase;

            view.OnIngredientButtonPressed += HandleIngredientButtonPressed;
        }

        public void StartCooking()
        {
            view.Show();
        }

        private void HandleIngredientButtonPressed(string ingredientKey)
        {
            selectIngredientUseCase.Select(ingredientKey);

            if(selectIngredientUseCase.IsSelected(ingredientKey))
            {
                Debugger.Log($"Ingredient {ingredientKey} selected");
                view.ShowCookingIngredientImage(
                    ingredientKey,
                    spriteProviderService.LoadSprite(ingredientKey)
                );
            }
            else
            {
                Debugger.Log($"Ingredient {ingredientKey} deselected");
                view.HideCookingIngredientImage(ingredientKey);
            }
        }

        private void Dispose()
        {
            view.OnIngredientButtonPressed -= HandleIngredientButtonPressed;
        }
    }
}