using Cysharp.Threading.Tasks;
using StreetFoodGame.Application.Interfaces;
using StreetFoodGame.Domain.Enums;

namespace StreetFoodGame.Infrastructure.Services
{
    public class UnityApplicationService : IApplicationService
    {
        private readonly ISceneService sceneService;

        public AppState CurrentState => currentState;
        private AppState currentState = AppState.None;

        private string sceneToUnload;
        private string sceneToLoad;

        public UnityApplicationService(ISceneService sceneService)
        {
            this.sceneService = sceneService;
        }

        public async UniTask ChangeState(AppState newState)
        {
            if(currentState == newState) return;

            currentState = newState;
            
            sceneToLoad = newState switch
            {
                AppState.MainMenu => "MainMenu",
                AppState.Gameplay => "Gameplay",
                _ => null
            };

            await sceneService.LoadScene(
                sceneToLoad,
                () =>
                {
                    sceneToUnload = sceneToLoad;
                    sceneToLoad = null;
                }
            );
        }

        public void Quit()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            UnityEngine.Application.Quit();
            #endif
        }
    }
}