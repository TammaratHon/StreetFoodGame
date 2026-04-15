namespace StreetFoodGame.Domain.Entities
{
    [System.Serializable]
    public class FoodData
    {
        public string key;
        public string category;
        public string name;
        public int unlocked_day;
        public int price;
    }
}