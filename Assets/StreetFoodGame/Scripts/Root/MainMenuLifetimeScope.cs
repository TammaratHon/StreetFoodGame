using StreetFoodGame.Application.Interfaces;
using StreetFoodGame.Presentation.Presenters;
using StreetFoodGame.Presentation.Views;
using VContainer;
using VContainer.Unity;

namespace StreetFoodGame.Root
{
    public class MainMenuLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<MainMenuPresenter>();
            builder.RegisterComponentInHierarchy<MainMenuView>().As<IMainMenuView>();
        }
    }
}