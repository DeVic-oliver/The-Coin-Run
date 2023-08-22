namespace Assets.Scripts.Core
{
    using UnityEngine;
    using UnityEngine.Events;

    public class CoinDetector : MonoBehaviour
    {
        public UnityEvent<int> OnCollectPoint;

        private int _playerPoints;


        public void CollectCoin(int points)
        {
            _playerPoints += points;
            OnCollectPoint?.Invoke(_playerPoints);
        }

        private void Start()
        {
            _playerPoints = 0;
        }

    }
}