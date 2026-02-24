using System.Collections.Generic;

namespace StreetFoodGame.Domain.Entities
{
    public class Recipe
    {
        public string Name { get; private set; }
        public List<IngredientByStep> IngredientsByStep { get; private set; }

        public Recipe(string name, List<IngredientByStep> ingredientsByStep)
        {
            Name = name;
            IngredientsByStep = ingredientsByStep;
        }
    }
}