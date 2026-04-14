namespace StreetFoodGame.Application.Interfaces
{
    public interface ISpriteProviderService
    {
        object LoadSprite(string spritePath);
        object LoadSpriteInSheet(string sheetPath, string spriteName);
    }
}