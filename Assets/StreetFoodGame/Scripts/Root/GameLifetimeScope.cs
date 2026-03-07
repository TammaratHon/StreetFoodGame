using StreetFoodGame.Application.Interfaces;
using StreetFoodGame.Infrastructure.Services;

using VContainer;
using VContainer.Unity;

namespace StreetFoodGame.Root
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ISceneService, UnitySceneService>(Lifetime.Singleton);
            builder.Register<IApplicationService, UnityApplicationService>(Lifetime.Singleton);

            builder.RegisterEntryPoint<GameStarter>();

            DontDestroyOnLoad(gameObject);
        }
    }
}