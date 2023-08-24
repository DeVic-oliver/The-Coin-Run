namespace Assets.Scripts.Items
{
    using Assets.Scripts.Core;
    using Photon.Pun;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Events;

    [RequireComponent(typeof(Collider))]
    public class Coin : MonoBehaviourPun
    {
        public UnityEvent OnCollected;

        public CoinSpawner Spawner { get; set; }

        [SerializeField] private int _coinPoints;
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private float _rotationSpeed = 35f;
        [SerializeField] private Collider _collider;


        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        private void Awake()
        {
            if(_collider == null)
                _collider = GetComponent<Collider>();
        }

        private void Update()
        {
            transform.Rotate(_rotationSpeed * Time.deltaTime * Vector3.up); 
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<CoinDetector>(out var coinDetector))
            {
                coinDetector.CollectCoin(_coinPoints);
                StartCoroutine("CallEventsThenDisableAfterDelay");
            }
        }

        private IEnumerator CallEventsThenDisableAfterDelay()
        {
            OnCollected?.Invoke();
            DisableColliderAndRenderer();
            yield return new WaitForSeconds(1.5f);
            gameObject.SetActive(false);
        }

        private void DisableColliderAndRenderer()
        {
            _collider.enabled = false;
            _renderer.enabled = false;
        }

        private void OnDisable()
        {
            if (Spawner != null)
                Spawner.BackToPool(this);
        }

        private void OnEnable()
        {
            EnableColliderAndRenderer();
        }

        private void EnableColliderAndRenderer()
        {
            _collider.enabled = true;
            _renderer.enabled = true;
        }

    }
}
