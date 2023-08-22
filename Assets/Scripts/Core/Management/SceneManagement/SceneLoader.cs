namespace Assets.Scripts.Core.Management.SceneManagement
{
    using UnityEngine.SceneManagement;
    
    public class SceneLoader
    {
        public int CurrentSceneBuildIndex { get; private set; }

        private readonly int _fallbackSceneBuildIndex = 0;


        public SceneLoader() 
        {
            SetCurrentSceneBuildIndex();
        }

        private void SetCurrentSceneBuildIndex()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            CurrentSceneBuildIndex = currentScene.buildIndex;
        }

        public void RestartScene()
        {
            SceneManager.LoadScene(CurrentSceneBuildIndex);
        }

    }
}