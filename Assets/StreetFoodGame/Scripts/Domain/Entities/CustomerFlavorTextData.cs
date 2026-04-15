namespace StreetFoodGame.Domain.Entities
{
    [System.Serializable]
    public class CustomerFlavorTextData
    {
        public string key;
        public string[] happy;
        public string[] neutral;
        public string[] impatient;
        public string[] angry;
    }
}