using UnityEngine;
using Zenject;

namespace Assets.Utils
{
    public class GameStarterBehaviour : MonoBehaviour
    {
        private SceneLoaderBehaviour _sceneLoader;

        [Inject]
        private void ZenjectInit(SceneLoaderBehaviour sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Start()
        {
            _sceneLoader.LoadScene(GameScene.level_main_menu);
        }
    }
}
