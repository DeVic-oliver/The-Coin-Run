namespace Assets.Scripts.Core
{
    using UnityEngine;
    using UnityEngine.Events;

    public class CoinDetector : MonoBehaviour
    {
        public UnityEvent<int> OnCollectPoint;
        public int PlayerPoints { get; private set; }


        public void CollectCoin(int points)
        {
            PlayerPoints += points;
            OnCollectPoint?.Invoke(PlayerPoints);
        }

        private void Start()
        {
            PlayerPoints = 0;
        }

    }
}