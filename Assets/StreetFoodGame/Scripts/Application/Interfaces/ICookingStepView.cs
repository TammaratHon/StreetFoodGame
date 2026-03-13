using Cysharp.Threading.Tasks;

namespace StreetFoodGame.Application.Interfaces
{
    public interface ICookingStepView : IView
    {
        void ShowCookingStep(int stepIndex);
        UniTask ShowCookingGauge(int gaugeIndex, float delay = 0f);
        void ShowIngredient(string ingredientKey, object spriteAsset);
        void HideIngredient(string ingredientKey);
        void HideAllIngredients();
    }
}