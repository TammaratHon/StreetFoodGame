using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    // Shared services
    private ISceneService sceneService;

    // Presenters
    private MainMenuPresenter mainMenuPresenter;

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

        mainMenuView.OnStartGameButtonPressed += () =>
        {
            mainMenuView.Hide();
            OnGameplayLoaded();
        };

        mainMenuPresenter = new MainMenuPresenter(mainMenuView, sceneService);
        mainMenuPresenter.Show();

        Debugger.Log("Game Bootstrapper initialized and Main Menu presented.");
    }

    private void OnGameplayLoaded()
    {
        sceneService.UnloadScene(
            "MainMenu",
            () =>
            {
                sceneService.LoadSceneAdditive(
                    "Gameplay",
                    () =>
                    {
                        var gameplayView = UnityEngine.Object.FindObjectOfType<GameplayView>();
                        if (gameplayView == null)
                        {
                            Debugger.LogError("GameplayView not found in the scene.");
                            return;
                        }

                        var gameplayPresenter = new GameplayPresenter(gameplayView, sceneService);
                        gameplayPresenter.StartGameplay();
                    }
                );

            }
        );
    }
}