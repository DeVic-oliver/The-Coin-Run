namespace Assets.Scripts.Core
{
    using UnityEngine;

    
    public class GameObjectActiveToggler : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObjectToToggle;


        public void ToggleGameObjectActive()
        {
            bool active = (_gameObjectToToggle.activeSelf) ? false : true;
            _gameObjectToToggle.SetActive(active);
        }
    }
}