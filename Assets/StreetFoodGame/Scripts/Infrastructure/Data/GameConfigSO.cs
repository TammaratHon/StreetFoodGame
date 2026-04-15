using System.Collections.Generic;
using UnityEngine;

namespace StreetFoodGame.Infrastructure.Data
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "StreetFoodGame/GameConfig")]
    public class GameConfigSO : ScriptableObject
    {
        public List<FoodDataSO> foodDataList;
        public List<RecipeDataSO> recipeDataList;
        public List<CustomerDataSO> customerDataList;
    }
}