using UnityEngine;
using StreetFoodGame.Application.Interfaces;

namespace StreetFoodGame.Infrastructure.Services
{
    public class UnityResourceSpriteProvider : ISpriteProviderService
    {
        public object LoadSprite(string spriteName)
        {
            string path = $"Graphics2D/IngredientIcons/Highlight/{spriteName}";
            return Resources.Load<Sprite>(path);
        }
    }
}