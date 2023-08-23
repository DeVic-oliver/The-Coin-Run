namespace Assets.Scripts.Items
{
    using Assets.Scripts.Core;
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    public class Coin : MonoBehaviour
    {
        public CoinSpawner Spawner { get; set; }

        [SerializeField] private int _coinPoints;

        [SerializeField] private float _rotationSpeed = 35f;


        private void Update()
        {
            transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime); 
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<CoinDetector>(out var coinDetector))
            {
                coinDetector.CollectCoin(_coinPoints);
                gameObject.SetActive(false);
            }    
        }

        private void OnDisable()
        {
            if (Spawner != null)
                Spawner.BackToPool(this);
        }

    }
}
