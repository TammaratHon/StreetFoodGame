using System;
using System.Collections.Generic;
using StreetFoodGame.Domain.Entities;
using StreetFoodGame.Domain.Interfaces;

namespace StreetFoodGame.Application.Usecases
{
    public class CookingUseCase
    {
        private readonly List<Recipe> recipes = new List<Recipe>();
        private readonly List<string> currentIngredients = new List<string>();

        private int currentCookCount = 0;
        public int CurrentCookCount => currentCookCount;
        private int currentStepIndex = 0;
        public int CurrentStepIndex => currentStepIndex;

        public CookingUseCase(IRecipeRepository recipeRepository)
        {
            recipes = recipeRepository.GetAllRecipes();
        }

        public void AddIngredient(string ingredientKey)
        {
            currentIngredients.Add(ingredientKey);
        }

        public void RemoveIngredient(string ingredientKey)
        {
            if(currentIngredients.Contains(ingredientKey))
            {
                currentIngredients.Remove(ingredientKey);
            }
        }

        public void Reset()
        {
            currentIngredients.Clear();
            currentCookCount = 0;
            currentStepIndex = 0;
        }

        public bool ProcessCookingCount()
        {
            if(!HasIngredients()) return false; // No ingredients, cannot process cook count
            if(!CheckIngredientsMatchAnyRecipe()) return false; // Ingredients don't match any recipe, cannot process cook count

            currentCookCount++;

            return true;
        }

        public bool ProcessCookingStep(out Menu menu)
        {
            menu = null;
            if (!HasIngredients()) return false; // No ingredients, cannot process step
            if (!CheckIngredientsMatchAnyRecipe(out Recipe matchedRecipe)) return false; // Ingredients don't match any recipe, cannot process step

            currentIngredients.Clear(); // Clear ingredients for the next step

            if(matchedRecipe != null && currentStepIndex >= matchedRecipe.IngredientsByStep.Count - 1)
            {
                currentStepIndex = 0; // Reset for next cooking session
                menu = new Menu(matchedRecipe.Name);
            } else
            {
                currentStepIndex++;
            }

            currentCookCount = 0; // Reset cook count for the next step
                
            return true;
        }

        public bool IsCookingCountAtMax()
        {
            return currentCookCount >= 3;
        }

        private bool CheckIngredientsMatchAnyRecipe()
        {
            return CheckIngredientsMatchAnyRecipe(out Recipe matchedRecipe);
        }

        private bool CheckIngredientsMatchAnyRecipe(out Recipe matchedRecipe)
        {
            matchedRecipe = null;
            List<Recipe> candidates = new List<Recipe>();

            foreach (var rec in recipes)
            {
                if (currentStepIndex < rec.IngredientsByStep.Count)
                {
                    candidates.Add(rec);
                }
            }

            foreach (var rec in candidates)
            {
                // If ingredient count doesn't match, skip
                if (rec.IngredientsByStep[currentStepIndex].ingredients.Count
                    != currentIngredients.Count) continue;

                // check ingredients in current ingredients and recipe ingredients
                bool allMatch = true;
                foreach (var ingredient in rec.IngredientsByStep[currentStepIndex].ingredients)
                {
                    // If any ingredient in the recipe step is not in the current ingredients, it's not a match
                    if (!currentIngredients.Contains(ingredient.Name))
                    {
                        allMatch = false;
                        break;
                    }
                }

                if (allMatch)
                {
                    matchedRecipe = rec;
                    return true; // Found a matching recipe for the current step
                }
            }

            return false;
        }

        public bool HasIngredients()
        {
            return currentIngredients.Count > 0;
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