using System;
using UnityEngine;
using UnityEngine.UI;
using StreetFoodGame.Application.Interfaces;

namespace StreetFoodGame.Presentation.Views
{
    public class GameplayView : MonoBehaviour, IGameplayView
    {
        // UI Elements
        [SerializeField] private Button optionButton;

        // Events
        public event Action OnOptionButtonPressed;

        private void Awake()
        {
            optionButton.onClick.AddListener(HandleOptionButtonPressed);
        }

        private void HandleOptionButtonPressed()
        {
            OnOptionButtonPressed?.Invoke();
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