using System.Collections.Generic;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    // Shared services
    private ISceneService sceneService;

    // Presenters
    private MainMenuPresenter mainMenuPresenter;

    // Repositories (can be used by presenters or other services)
    [SerializeField] private List<RecipeDataSO> recipeDataSOList;
    [SerializeField] private List<CustomerDataSO> customerDataSOList;

    private void Start()
    {
        sceneService = new SceneService();

        sceneService.LoadSceneAdditive(
            "MainMenu",
            () => OnMainMenuLoaded()
        );
    }

    private void OnMainMenuLoaded()
    {
        var mainMenuView = FindObjectOfType<MainMenuView>();
        if(mainMenuView ==  null)
        {
            Debugger.LogError("MainMenuView not found in the scene.");
            return;
        }

        mainMenuPresenter = new MainMenuPresenter(
            mainMenuView,
            sceneService,
            () => {
                sceneService.UnloadScene(
                    "MainMenu",
                    () => sceneService.LoadSceneAdditive(
                        "Gameplay",
                        () => OnGameplayLoaded()
                    )
                );
            }
        );
        mainMenuPresenter.Show();

        Debugger.Log("Game Bootstrapper initialized and Main Menu presented.");
    }

    private void OnGameplayLoaded()
    {
        // Find the GameplaySceneContext in the loaded scene to access its views and other components.
        var ctx = FindObjectOfType<GameplaySceneContext>();
        if (ctx == null)
        {
            Debugger.LogError("GameplaySceneContext not found in the scene.");
            return;
        }

        // Initialize repositories with data from ScriptableObjects
        var recipeRepository = new RecipeRepository(recipeDataSOList);
        var customerRepository = new CustomerRepository(customerDataSOList);
        var orderFactory = new OrderFactory(recipeRepository, customerRepository);
        var orderQueueManager = new OrderQueueManager();

        // Create the GameplayPresenter and wire everything together
        var gameplayPresenter = new GameplayPresenter(
            ctx.gameplayView,
            ctx.cookingView,
            sceneService,
            orderFactory,
            orderQueueManager
        );
        
        gameplayPresenter.StartGameplay();
    }
}