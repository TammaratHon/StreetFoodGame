namespace StreetFoodGame.Application.Interfaces
{
    public interface ICookingStepView : IView
    {
        void ShowCookingStep(int stepIndex);
        void ShowIngredient(string ingredientKey, object spriteAsset);
        void HideIngredient(string ingredientKey);
        void HideAllIngredients();
    }
}