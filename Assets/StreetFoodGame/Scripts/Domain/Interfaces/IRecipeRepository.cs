using System.Collections.Generic;

public interface IRecipeRepository
{
    Recipe GetRecipeByFoodItemName(string foodItemName);
    Recipe GetRandomRecipe();
    List<Recipe> GetAllRecipes();
}