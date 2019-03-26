using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Utils
{
    [RequireComponent(typeof(Button))]
    public class LoadSceneButton : MonoBehaviour
    {
        [SerializeField]
        private GameScene _sceneToLoad;

        private Button _loadSceneButton;

        private SceneLoaderBehaviour _sceneLoader;

        [Inject]
        private void ZenjectInit(SceneLoaderBehaviour sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Start()
        {
            _loadSceneButton = GetComponent<Button>();

            if (_loadSceneButton == null)
            {
                Debug.LogError("Required component was not found!");
                return;
            }

            _loadSceneButton.onClick.AddListener(
                delegate { _sceneLoader.LoadScene(_sceneToLoad); });
        }
    }
}