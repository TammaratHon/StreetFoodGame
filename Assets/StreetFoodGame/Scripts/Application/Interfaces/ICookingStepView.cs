using System;
using Cysharp.Threading.Tasks;

namespace StreetFoodGame.Application.Interfaces
{
    public interface ICookingStepView : IView
    {
        void ShowCookingStep(int stepIndex);
        void ShowReadyToServeStep();
        UniTask ShowCookingGauge(int gaugeIndex, float delay = 0f);
        void ShowCookingIcon(string ingredientKey, object spriteAsset);
        void HideCookingIcon(string ingredientKey);
        void HideAllCookingIcons(Action onComplete = null);
    }
}