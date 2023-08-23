namespace Assets.Scripts.Core.Management.SceneManagement
{
    using UnityEngine;

    public class ScenePauser
    {
        public ScenePauser()
        {
            UnpauseScene();
        }

        public void TogglePauseScene()
        {
            if (IsGamePaused()) 
            {
                UnpauseScene();
            }
            else
            {
                PauseScene();
            }
        }

        public bool IsGamePaused()
        {
            return (Time.timeScale == 0);
        }

        public void UnpauseScene()
        {
            Time.timeScale = 1;
        }

        public void PauseScene()
        {
            Time.timeScale = 0;
        }

    }
}