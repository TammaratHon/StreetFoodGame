using UnityEngine;

namespace StreetFoodGame.Infrastructure.Data
{
    [CreateAssetMenu(fileName = "IngredientData", menuName = "StreetFoodGame/IngredientData")]
    public class IngredientDataSO : ScriptableObject
    {
        public string ingredientName;
    }
}