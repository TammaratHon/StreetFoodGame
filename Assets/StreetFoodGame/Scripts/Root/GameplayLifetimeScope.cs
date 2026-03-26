using System.Collections.Generic;

using UnityEngine;

using VContainer;
using VContainer.Unity;

using StreetFoodGame.Domain.Enums;
using StreetFoodGame.Domain.Interfaces;

using StreetFoodGame.Application.Usecases;
using StreetFoodGame.Application.Interfaces;

using StreetFoodGame.Infrastructure.Data;
using StreetFoodGame.Infrastructure.Services;
using StreetFoodGame.Infrastructure.Factories;
using StreetFoodGame.Infrastructure.Repositories;

using StreetFoodGame.Presentation.Views;
using StreetFoodGame.Presentation.Context;
using StreetFoodGame.Presentation.Presenters;
using StreetFoodGame.Presentation.Components;

namespace StreetFoodGame.Root
{
    public class GameplayLifetimeScope : LifetimeScope
    {
        [Header("Data")]
        [SerializeField] private GameConfigSO gameConfig;
        
        [Header("Audio")]
        [SerializeField] private AudioPlayer audioPlayer;
        [SerializeField] private List<AudioClipWithId> audioClips;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(gameConfig.recipeDataList);
            builder.RegisterInstance(gameConfig.customerDataList);
            builder.RegisterInstance(audioPlayer);

            // Convert List<AudioClipWithId> to Dictionary<SoundId, AudioClip>
            var convertedAudioClips = new Dictionary<SoundId, AudioClip>();
            foreach (var clip in audioClips) {
                convertedAudioClips[clip.id] = clip.clip;
            }
            builder.RegisterInstance(convertedAudioClips);

            builder.RegisterEntryPoint<GameplayPresenter>();

            builder.RegisterComponentInHierarchy<GameplaySceneContext>();
        
            builder.RegisterComponentInHierarchy<GameplayView>().As<IGameplayView>();
            builder.RegisterComponentInHierarchy<CookingView>().As<ICookingView>();
            builder.RegisterComponentInHierarchy<CookingStepView>().As<ICookingStepView>();
            builder.RegisterComponentInHierarchy<OrderQueueView>().As<IOrderQueueView>();

            builder.Register<IOrderFactory, OrderFactory>(Lifetime.Scoped);
            builder.Register<ISpriteProviderService, UnityResourceSpriteProvider>(Lifetime.Scoped);
            builder.Register<IAudioService, UnityAudioService>(Lifetime.Scoped);

            // Scene-specific use cases
            builder.Register<StartGameUseCase>(Lifetime.Scoped);
            builder.Register<ReceiveOrderUseCase>(Lifetime.Scoped);
            builder.Register<CookingUseCase>(Lifetime.Scoped);

            // Scene-specific repositories
            builder.Register<IRecipeRepository, RecipeRepository>(Lifetime.Scoped);
            builder.Register<ICustomerRepository, CustomerRepository>(Lifetime.Scoped);
            builder.Register<IOrderQueueRepository, OrderQueueRepository>(Lifetime.Scoped);

            builder.Register<CookingPresenter>(Lifetime.Scoped);
            builder.Register<OrderQueuePresenter>(Lifetime.Scoped);
        }
    }
}