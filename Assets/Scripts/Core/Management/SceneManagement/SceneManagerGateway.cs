namespace Assets.Scripts.Core.Management.SceneManagement
{
    using System.Collections;
    using UnityEngine;

    public class SceneManagerGateway : MonoBehaviour
    {
        private ScenePauser _scenePauser;
        private SceneLoader _sceneLoader;

        
        public bool IsGamePaused()
        {
            return _scenePauser.IsGamePaused();
        }

        public void PauseGame()
        {
            _scenePauser.PauseScene();
        }

        public void UnpauseGame()
        {
            _scenePauser.UnpauseScene();
        }

        public void TogglePauseState()
        {
            _scenePauser.TogglePauseScene();
        }

        public void RestartSceneImmediately()
        {
            _sceneLoader.RestartScene();
        }

        public void RestartSceneAfterThreeSeconds()
        {
            StartCoroutine("RestartSceneCoroutine");
        }

        private IEnumerator RestartSceneCoroutine()
        {
            float seconds = 3;
            yield return new WaitForSecondsRealtime(seconds);
            _sceneLoader.RestartScene();
        }

        private void Awake()
        {
            _scenePauser = new ScenePauser();
            _sceneLoader = new SceneLoader();
        }
    }
}