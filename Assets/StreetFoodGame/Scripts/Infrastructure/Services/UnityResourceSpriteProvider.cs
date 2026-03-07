using UnityEngine;
using StreetFoodGame.Application.Interfaces;

namespace StreetFoodGame.Infrastructure.Services
{
    public class UnityResourceSpriteProvider : ISpriteProviderService
    {
        public object LoadSprite(string spriteName)
        {
            string path = $"Graphics2D/IngredientIcons/{spriteName}";
            return Resources.Load<Sprite>(path);
        }
    }
}