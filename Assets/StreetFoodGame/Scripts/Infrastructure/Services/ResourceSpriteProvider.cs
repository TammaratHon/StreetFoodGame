using StreetFoodGame.Application.Interfaces;
using UnityEngine;

namespace StreetFoodGame.Infrastructure.Services
{
    public class ResourceSpriteProvider : ISpriteProviderService
    {
        public object LoadSprite(string spriteName)
        {
            string path = $"Graphics2D/IngredientIcons/{spriteName}";
            return Resources.Load<Sprite>(path);
        }
    }
}