using System;
using UnityEngine;
using StreetFoodGame.Application.Interfaces;
using StreetFoodGame.Presentation.Components;
using UnityEngine.UI;

namespace StreetFoodGame.Presentation.Views
{
    public class CookingView : MonoBehaviour, ICookingView
    {
        [SerializeField] private IngredientButton[] _ingredientButton;
        [SerializeField] private CookingIngredient[] _cookingIngredient;

        [SerializeField] private CookingButton _cookButton;

        public event Action<string> OnIngredientButtonPressed;
        public event Action OnCookButtonPressed;

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

            _cookButton.Initialize(() => OnCookButtonPressed?.Invoke());
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

        public void HideAllCookingIngredientImages()
        {
            foreach (var image in _cookingIngredient)
            {
                image.HideIngredient();
            }
        }
    }
}