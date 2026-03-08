using System;
using System.Collections.Generic;
using UnityEngine;

namespace StreetFoodGame.Infrastructure.Data
{
    [CreateAssetMenu(fileName = "RecipeData", menuName = "StreetFoodGame/RecipeData")]
    public class RecipeDataSO : ScriptableObject
    {
        public string foodItemName;
        public List<IngredientSOByStep> ingredientBySteps;
    }

    [Serializable]
    public class IngredientSOByStep
    {
        public List<IngredientDataSO> ingredients;
    }
}