using UnityEngine;
using System.Collections.Generic;
using StreetFoodGame.Application.Interfaces;
using StreetFoodGame.Presentation.Components;

namespace StreetFoodGame.Presentation.Views
{
    public class CookingStepView : MonoBehaviour, ICookingStepView
    {
        [SerializeField] private List<CookingIngredient> _cookingIngredients;
        [SerializeField] private List<GameObject> _cookingSteps;
        [SerializeField] private List<GameObject> _cookingGauges;
        
        private void Awake()
        {
            _cookingIngredients.ForEach(ingredient => ingredient.gameObject.SetActive(false));
            _cookingSteps.ForEach(step => step.SetActive(false));
            _cookingGauges.ForEach(gauge => gauge.SetActive(false));
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void ShowCookingGauge(int gaugeIndex)
        {
            if (gaugeIndex < 0 || gaugeIndex >= _cookingGauges.Count) return;

            _cookingGauges.ForEach(gauge => gauge.SetActive(false));
            _cookingGauges[gaugeIndex].SetActive(true);
        }

        public void ShowCookingStep(int stepIndex)
        {
            if (stepIndex < 0 || stepIndex >= _cookingSteps.Count) return;

            _cookingSteps.ForEach(step => step.SetActive(false));
            _cookingSteps[stepIndex].SetActive(true);
        }

        public void ShowIngredient(string ingredientKey, object spriteAsset)
        {
            foreach (var ingredient in _cookingIngredients)
            {
                if(ingredient.gameObject.activeSelf) continue;

                ingredient.ShowIngredient(ingredientKey, spriteAsset);
                break;
            }
        }

        public void HideIngredient(string ingredientKey)
        {
            foreach (var ingredient in _cookingIngredients)
            {
                if (ingredient.IngredientKey != ingredientKey) continue;

                ingredient.HideIngredient();
                break;
            }
        }

        public void HideAllIngredients()
        {
            _cookingIngredients.ForEach(ingredient => ingredient.HideIngredient());
        }
    }
}