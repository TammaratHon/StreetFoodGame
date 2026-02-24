using StreetFoodGame.Application.Interfaces;

namespace StreetFoodGame.Infrastructure.Services
{
    public class ApplicationService : IApplicationService
    {
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