using System;
using UnityEngine;
using StreetFoodGame.Application.Interfaces;
using StreetFoodGame.Presentation.Components;

namespace StreetFoodGame.Presentation.Views
{
    public class CookingView : MonoBehaviour, ICookingView
    {
        [SerializeField] private IngredientButton[] _ingredientButton;

        [SerializeField] private CookingButton _cookButton;

        public event Action<string> OnIngredientButtonPressed;
        public event Action OnCookButtonPressed;

        private void Awake()
        {
            foreach (var button in _ingredientButton)
            {
                button.Initialize(() => OnIngredientButtonPressed?.Invoke(button.Key));
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
    }
}