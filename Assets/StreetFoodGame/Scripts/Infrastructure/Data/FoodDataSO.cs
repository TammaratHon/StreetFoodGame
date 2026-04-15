using UnityEngine;

namespace StreetFoodGame.Infrastructure.Data
{
    [CreateAssetMenu(fileName = "FoodData", menuName = "StreetFoodGame/FoodData")]
    public class FoodDataSO : ScriptableObject
    {
        public string foodName;
        public bool isMainFood;
    }
}