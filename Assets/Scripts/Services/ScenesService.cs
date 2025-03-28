using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services
{
    public class ScenesService : MonoBehaviour
    {
        private const string LoadScene = nameof(LoadScene);
        private const string GameScene = nameof(GameScene);

        public void LoadGameScene()
        {
            SetNameScene(GameScene);
        }

        public void LoadLoadingScene()
        {
            SetNameScene(LoadScene);
        }

        private void SetNameScene(string nameScene)
        {
            SceneManager.LoadScene(nameScene);
        }
    }
}