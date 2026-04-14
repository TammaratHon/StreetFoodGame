using UnityEngine;
using StreetFoodGame.Application.Interfaces;

namespace StreetFoodGame.Infrastructure.Services
{
    public class UnityResourceSpriteProvider : ISpriteProviderService
    {
        public object LoadSprite(string spritePath)
        {
            return Resources.Load<Sprite>(spritePath);
        }

        public object LoadSpriteInSheet(string sheetPath, string spriteName)
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>(sheetPath);
            foreach (var sprite in sprites)
            {
                if (sprite.name == spriteName)
                {
                    return sprite;
                }
            }
            return null;
        }
    }
}