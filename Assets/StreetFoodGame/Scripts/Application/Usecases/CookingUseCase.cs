using System.Collections.Generic;
using StreetFoodGame.Domain.Entities;
using StreetFoodGame.Domain.Interfaces;

namespace StreetFoodGame.Application.Usecases
{
    public class CookingUseCase
    {
        private readonly List<Recipe> recipes = new List<Recipe>();
        private readonly HashSet<string> currentIngredients = new HashSet<string>();

        private int currentStepIndex = 0;
        public int CurrentStepIndex => currentStepIndex;

        public CookingUseCase(IRecipeRepository recipeRepository)
        {
            recipes = recipeRepository.GetAllRecipes();
        }

        public void AddIngredient(string ingredientKey)
        {
            if(!currentIngredients.Contains(ingredientKey))
            {
                currentIngredients.Add(ingredientKey);
            }
        }

        public void RemoveIngredient(string ingredientKey)
        {
            if(currentIngredients.Contains(ingredientKey))
            {
                currentIngredients.Remove(ingredientKey);
            }
        }

        public bool Cook(out Menu menu)
        {
            if(currentIngredients.Count == 0)
            {
                menu = null;
                return false; // No ingredients, cannot cook
            }
            menu = null;
            // Check current step index is in range of any recipe
            List<Recipe> matchingRecipes = new List<Recipe>();

            foreach (var rec in recipes)
            {
                if (currentStepIndex < rec.IngredientsByStep.Count)
                {
                    matchingRecipes.Add(rec);
                }
            }

            foreach(var rec in matchingRecipes)
            {
                if (rec.IngredientsByStep[currentStepIndex].ingredients.Count
                    != currentIngredients.Count) continue;
                
                // check ingredients in current ingredients and recipe ingredients
                bool allMatch = true;
                foreach (var ingredient in rec.IngredientsByStep[currentStepIndex].ingredients)
                {
                    if (!currentIngredients.Contains(ingredient.Name))
                    {
                        allMatch = false;
                        break;
                    }
                }

                // If all ingredients match and it's the last step of the recipe, return the menu
                if (allMatch && currentStepIndex == rec.IngredientsByStep.Count - 1) 
                {
                    currentStepIndex = 0; // Reset for next cooking session
                    currentIngredients.Clear(); // Clear ingredients for the next cooking session
                    menu = new Menu(rec.Name);
                    return true;
                }
                else if(allMatch)
                {
                    currentIngredients.Clear(); // Clear ingredients for the next step
                    currentStepIndex++;
                    return true;
                }
            }

            return false;
        }

        public bool IsIngredientContained(string ingredientKey)
        {
            return currentIngredients.Contains(ingredientKey);
        }

        public bool IsIngredientSlotAvailable()
        {
            return currentIngredients.Count < 5;
        }

        public int GetCurrentIngredientCount()
        {
            return currentIngredients.Count;
        }
    }
}