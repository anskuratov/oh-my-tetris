using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Utils
{
    public class SceneLoaderBehaviour : MonoBehaviour
    {
        private const float millisecondsToWait = 1000f;

        [SerializeField]
        private AnimationsLoaderBehaviour _animationsLoader;

        private List<GameScene> _loadedScenes;

        private void Awake()
        {
            _loadedScenes = new List<GameScene>();
        }

        public void LoadScene(GameScene sceneToLoad, bool unloadOtherScenes = true) =>
            LoadSceneAsync(sceneToLoad, unloadOtherScenes);

        private async Task LoadSceneAsync(GameScene sceneToLoad, bool unloadOtherScenes)
        {
            _animationsLoader.StartLoading();

            var loadingTask = LoadSceneAsync(sceneToLoad);
            while (loadingTask.IsCompleted == false)
                await Task.Delay(TimeSpan.FromMilliseconds(millisecondsToWait));

            if (unloadOtherScenes && _loadedScenes.Count != 0)
            {
                loadingTask = UnloadScenesAsync();
                while (loadingTask.IsCompleted == false)
                    await Task.Delay(TimeSpan.FromMilliseconds(millisecondsToWait));
            }

            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int)sceneToLoad));

            _loadedScenes.Add(sceneToLoad);

            _animationsLoader.StopLoading();
        }

        private async Task UnloadScenesAsync()
        {
            foreach (var scene in _loadedScenes)
                await UnloadSceneAsync(scene);

            _loadedScenes.Clear();
        }

        private async Task LoadSceneAsync(GameScene sceneToLoad)
        {
            var loadingOperation = SceneManager.LoadSceneAsync((int)sceneToLoad, LoadSceneMode.Additive);

            while (loadingOperation.isDone == false)
                await Task.Delay(TimeSpan.FromMilliseconds(millisecondsToWait));
        }

        private async Task UnloadSceneAsync(GameScene sceneToUnload)
        {
            var unloadingOperation = SceneManager.UnloadSceneAsync((int)sceneToUnload);

            while (unloadingOperation.isDone == false)
                await Task.Delay(TimeSpan.FromMilliseconds(millisecondsToWait));
        }
    }

    public enum GameScene
    {
        level_main_menu,

        level_game
    }
}