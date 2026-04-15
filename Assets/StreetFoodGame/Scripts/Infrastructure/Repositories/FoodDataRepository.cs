using System.Collections.Generic;
using StreetFoodGame.Domain.Entities;
using StreetFoodGame.Domain.Interfaces;
using UnityEngine;
using Newtonsoft.Json;

namespace StreetFoodGame.Infrastructure.Repositories
{
    public class FoodDataRepository : IFoodDataRepository
    {
        private const string JSON_PATH = "JSON/FoodData";

        private readonly List<FoodData> mainFoods;
        private readonly List<FoodData> otherFoods;

        public FoodDataRepository()
        {
            TextAsset jsonFile = Resources.Load<TextAsset>(JSON_PATH);
            if(jsonFile == null)
            {
                throw new System.Exception($"Failed to load food data from path: {JSON_PATH}");
            }

            var foods = JsonConvert.DeserializeObject<List<FoodData>>(jsonFile.text);
            mainFoods = new List<FoodData>();
            otherFoods = new List<FoodData>();

            foreach(var food in foods)
            {
                if(food.category == "main")
                {
                    mainFoods.Add(food);
                }
                else
                {
                    otherFoods.Add(food);
                }
            }
            Debug.Log($"Loaded {mainFoods.Count} main foods and {otherFoods.Count} other foods from JSON.");
        }

        public FoodData GetMainFood()
        {
            if (mainFoods.Count == 0)
            {
                throw new System.InvalidOperationException("No main foods available in the repository.");
            }

            int randomIndex = Random.Range(0, mainFoods.Count);
            return mainFoods[randomIndex];
        }

        public FoodData GetRandomFoodWithoutMain()
        {
            if (otherFoods.Count == 0)
            {
                throw new System.InvalidOperationException("No other foods available in the repository.");
            }

            int randomIndex = Random.Range(0, otherFoods.Count);
            return otherFoods[randomIndex];
        }
    }
}