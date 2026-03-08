using System;
using UnityEngine;
using UnityEngine.UI;
using StreetFoodGame.Application.Interfaces;

namespace StreetFoodGame.Presentation.Views
{
    public class GameplayView : MonoBehaviour, IGameplayView
    {
        // UI Elements
        [SerializeField] private Button settingButton;
        [SerializeField] private Button cleanButton;
        [SerializeField] private Button recipeButton;

        // Events
        public event Action OnSettingButtonPressed;
        public event Action OnCleanButtonPressed;
        public event Action OnRecipeButtonPressed;

        private void Awake()
        {
            settingButton.onClick.AddListener(HandleSettingButtonPressed);
            cleanButton.onClick.AddListener(HandleCleanButtonPressed);
            recipeButton.onClick.AddListener(HandleRecipeButtonPressed);
        }

        private void HandleSettingButtonPressed()
        {
            OnSettingButtonPressed?.Invoke();
        }

        private void HandleCleanButtonPressed()
        {
            OnCleanButtonPressed?.Invoke();
        }

        private void HandleRecipeButtonPressed()
        {
            OnRecipeButtonPressed?.Invoke();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            settingButton.onClick.RemoveListener(HandleSettingButtonPressed);
            cleanButton.onClick.RemoveListener(HandleCleanButtonPressed);
            recipeButton.onClick.RemoveListener(HandleRecipeButtonPressed);
        }
    }
}