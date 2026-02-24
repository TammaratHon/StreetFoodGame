using System.Collections.Generic;

namespace StreetFoodGame.Application.Usecases
{
    public class SelectIngredientUseCase
    {
        private readonly HashSet<string> selectedIngredients = new HashSet<string>();

        public SelectIngredientUseCase()
        {
            
        }

        public void Select(string ingredientKey)
        {
            if (selectedIngredients.Contains(ingredientKey))
            {
                selectedIngredients.Remove(ingredientKey);
            }
            else
            {
                selectedIngredients.Add(ingredientKey);
            }
        }

        public bool IsSelected(string ingredientKey)
        {
            return selectedIngredients.Contains(ingredientKey);
        }
    }
}