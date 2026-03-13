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
    }
}