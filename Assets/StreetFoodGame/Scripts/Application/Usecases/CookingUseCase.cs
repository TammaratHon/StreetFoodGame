using System.Collections.Generic;
using StreetFoodGame.Domain.Entities;
using Utilities;

namespace StreetFoodGame.Application.Usecases
{
    public class CookingUseCase
    {
        private readonly List<Recipe> recipes = new List<Recipe>();
        private readonly HashSet<string> currentIngredients = new HashSet<string>();

        private int currentStepIndex = 0;

        public CookingUseCase(List<Recipe> recipes)
        {
            this.recipes = recipes;
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
                Debugger.Log("No ingredients added, cannot cook.");
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

            matchingRecipes.ForEach(
                rec => Debugger.Log($"Can make {rec.Name} with current ingredients: {string.Join(", ", rec.IngredientsByStep[currentStepIndex].ingredients)}")
            );

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
                    menu = new Menu(rec.Name);
                }

                // If all ingredients match, move to the next step of the recipe
                if(allMatch)
                {
                    currentIngredients.Clear(); // Clear ingredients for the next step
                    Debugger.Log($"Step {currentStepIndex + 1} of {rec.Name} matched!");
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
    }
}