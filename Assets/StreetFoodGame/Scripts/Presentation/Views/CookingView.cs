using System;
using UnityEngine;
using StreetFoodGame.Application.Interfaces;
using StreetFoodGame.Presentation.Components;

namespace StreetFoodGame.Presentation.Views
{
    public class CookingView : MonoBehaviour, ICookingView
    {
        [SerializeField] private IngredientButton[] _ingredientButton;
        [SerializeField] private CookingIngredient[] _cookingIngredient;

        public event Action<string> OnIngredientButtonPressed;

        private void Awake()
        {
            foreach (var button in _ingredientButton)
            {
                button.Initialize(() => OnIngredientButtonPressed?.Invoke(button.Key));
            }

            foreach (var image in _cookingIngredient)
            {
                image.gameObject.SetActive(false);
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void ShowCookingIngredientImage(string key, object spriteAsset)
        {
            foreach (var image in _cookingIngredient)
            {
                if (image.gameObject.activeSelf) continue;

                image.ShowIngredient(key, spriteAsset);
                break;
            }
        }

        public void HideCookingIngredientImage(string key)
        {
            foreach (var image in _cookingIngredient)
            {
                if (image.IngredientKey != key) continue;

                image.HideIngredient();
                break;
            }
        }
    }
}