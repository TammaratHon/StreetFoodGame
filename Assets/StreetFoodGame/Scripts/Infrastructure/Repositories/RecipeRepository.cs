using System;
using System.Collections.Generic;

public class RecipeRepository : IRecipeRepository
{
    private readonly List<Recipe> recipeDataList;

    public RecipeRepository(List<RecipeDataSO> recipeDataList)
    {
        this.recipeDataList = new List<Recipe>();
        foreach (var data in recipeDataList)
        {
            var recipe = ConvertToRecipe(data);
            this.recipeDataList.Add(recipe);
        }
    }

    public List<Recipe> GetAllRecipes()
    {
        return recipeDataList;
    }

    public Recipe GetRandomRecipe()
    {
        if(recipeDataList.Count == 0)
        {
            throw new System.InvalidOperationException("No recipes available in the repository.");
        }

        Random random = new Random();
        int randomIndex = random.Next(recipeDataList.Count);
        return recipeDataList[randomIndex];
    }

    public Recipe GetRecipeByFoodItemName(string foodItemName)
    {
        return recipeDataList.Find(recipe => recipe.Name == foodItemName);
    }

    private Recipe ConvertToRecipe(RecipeDataSO data)
    {
        List<IngredientByStep> ingredientBySteps = new List<IngredientByStep>();
        foreach (var step in data.ingredientBySteps)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (var ingredientData in step.ingredients)
            {
                ingredients.Add(new Ingredient(ingredientData.ingredientName));
            }
            ingredientBySteps.Add(new IngredientByStep(ingredients));
        }
        return new Recipe(data.foodItemName, ingredientBySteps);
    }
}