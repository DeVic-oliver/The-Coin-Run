namespace Assets.Scripts.UI
{
    using Assets.Scripts.Core.Management.SceneManagement;
    using UnityEngine;
    using UnityEngine.UI;

    public class PauseButtonSpriteChanger : MonoBehaviour
    {
        [SerializeField] private Image _buttonImage;
        [SerializeField] private Sprite _pauseSprite;
        [SerializeField] private Sprite _playSprite;
        [SerializeField] private SceneManagerGateway _sceneManager;


        public void SwitchSpritsAccordinglyGameState()
        {
            if (_sceneManager.IsGamePaused())
            {
                _buttonImage.sprite = _playSprite;
            }
            else
            {
                _buttonImage.sprite = _pauseSprite;
            }
        }

    }
}
