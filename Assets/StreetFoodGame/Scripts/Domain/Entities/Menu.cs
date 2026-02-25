namespace StreetFoodGame.Domain.Entities
{
    public class Menu
    {
        public string Name { get; private set; }

        public Menu(string name)
        {
            Name = name;
        }
    }
}