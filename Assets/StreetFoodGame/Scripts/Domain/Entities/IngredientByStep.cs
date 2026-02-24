using System.Collections.Generic;

namespace StreetFoodGame.Domain.Entities
{
    public class IngredientByStep
    {
        public IngredientByStep(List<Ingredient> ingredients)
        {
            this.ingredients = ingredients;
        }

        public List<Ingredient> ingredients { get; private set; }
    }
}