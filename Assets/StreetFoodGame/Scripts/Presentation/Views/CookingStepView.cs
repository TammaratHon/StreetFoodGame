using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using StreetFoodGame.Application.Interfaces;
using StreetFoodGame.Presentation.Components;
using Cysharp.Threading.Tasks;

namespace StreetFoodGame.Presentation.Views
{
    public class CookingStepView : MonoBehaviour, ICookingStepView
    {
        [SerializeField] private List<CookingIngredient> _cookingIngredients;
        [SerializeField] private List<GameObject> _cookingSteps;
        [SerializeField] private List<GameObject> _cookingGauges;

        [Header("Locators")]
        [SerializeField] private List<Transform> ingredientLocatorsStep1;
        [SerializeField] private List<Transform> ingredientLocatorsStep2;
        [SerializeField] private List<Transform> ingredientLocatorsStep3;
        [SerializeField] private List<Transform> ingredientLocatorsStep4;
        [SerializeField] private List<Transform> ingredientLocatorsStep5;

        private List<Transform> currentIngredientLocators = new List<Transform>();
        
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

        public async UniTask ShowCookingGauge(int gaugeIndex, float delay = 0f)
        {
            if (gaugeIndex < 0 || gaugeIndex >= _cookingGauges.Count) return;

            if(delay > 0f)
            {
                await UniTask.Delay(System.TimeSpan.FromSeconds(delay));
            }

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
            int activeIngredientCount = _cookingIngredients.FindAll(ingredient => ingredient.gameObject.activeSelf).Count;
            currentIngredientLocators = activeIngredientCount switch
            {
                0 => ingredientLocatorsStep1,
                1 => ingredientLocatorsStep2,
                2 => ingredientLocatorsStep3,
                3 => ingredientLocatorsStep4,
                4 => ingredientLocatorsStep5,
                _ => new List<Transform>()
            };

            int index = 0;
            foreach (var ingredient in _cookingIngredients)
            {
                if(ingredient.gameObject.activeSelf)
                {
                    ingredient.ChangePosition(currentIngredientLocators[index].position);
                } else
                {
                    ingredient.ChangePosition(currentIngredientLocators[index].position, true);
                    ingredient.ShowIngredient(ingredientKey, spriteAsset);
                    break;
                }
                
                index++;
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