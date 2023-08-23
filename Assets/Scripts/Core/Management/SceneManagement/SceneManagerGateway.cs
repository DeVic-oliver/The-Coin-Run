namespace Assets.Scripts.Core.Management.SceneManagement
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Events;

    public class SceneManagerGateway : MonoBehaviour
    {
        public UnityEvent OnPause;
        public UnityEvent OnResumeGame;

        private ScenePauser _scenePauser;
        private SceneLoader _sceneLoader;

        
        public void BackToLobby()
        {
            _sceneLoader.BackToLobby();
        }

        public void QuitGame()
        {
            _sceneLoader.QuitGame();
        }

        public bool IsGamePaused()
        {
            return _scenePauser.IsGamePaused();
        }

        public void PauseGame()
        {
            OnPause?.Invoke();
            _scenePauser.PauseScene();
        }

        public void UnpauseGame()
        {
            OnResumeGame?.Invoke();
            _scenePauser.UnpauseScene();
        }

        public void TogglePauseState()
        {
            InvokeEventsAccordinglyWithNextState();
            _scenePauser.TogglePauseScene();
        }

        private void InvokeEventsAccordinglyWithNextState()
        {
            if (_scenePauser.IsGamePaused())
            {
                OnResumeGame?.Invoke();
            }
            else
            {
                OnPause?.Invoke();
            }
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