namespace StreetFoodGame.Domain.Entities
{
    public class Food
    {
        public string Name { get; private set; }

        public Food(string name)
        {
            Name = name;
        }
    }
}