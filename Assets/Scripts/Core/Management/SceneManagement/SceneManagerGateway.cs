namespace Assets.Scripts.Core.Management.SceneManagement
{
    using UnityEngine;

    public class SceneManagerGateway : MonoBehaviour
    {
        private ScenePauser _scenePauser;
        private SceneLoader _sceneLoader;

        
        public void TogglePauseState()
        {
            _scenePauser.TogglePauseScene();
        }

        public void RestartScene()
        {
            _sceneLoader.RestartScene();
        }

        private void Awake()
        {
            _scenePauser = new ScenePauser();
            _sceneLoader = new SceneLoader();
        }

    }
}