using System.Collections.Generic;
using StreetFoodGame.Domain.Entities;

namespace StreetFoodGame.Domain.Interfaces
{
    public interface IRecipeRepository
    {
        Recipe GetRecipeByFoodItemName(string foodItemName);
        Recipe GetRandomRecipe();
        List<Recipe> GetAllRecipes();
    }
}