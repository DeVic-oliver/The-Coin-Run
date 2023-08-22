namespace Assets.Scripts.Items
{
    using Assets.Scripts.Core;
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int _coinPoints;


        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<CoinDetector>(out var coinDetector))
            {
                coinDetector.CollectCoin();
            }    
        }

    }
}
