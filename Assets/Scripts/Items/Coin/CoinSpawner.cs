namespace Assets.Scripts.Items
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [RequireComponent(typeof(CoinPool))]
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField] private Coin _coin;
        
        private CoinPool _coinPool;


        private void Awake()
        {
            _coinPool = GetComponent<CoinPool>();
            _coinPool.InitPool(_coin);
        }

        public void BackToPool(Coin coin)
        {
            _coinPool.Pool.Release(coin);
        }

        private void Start()
        {
            StartCoroutine("SpawnCoins");
        }
        
        private IEnumerator SpawnCoins()
        {
            float secondsToSpawn = 1.5f;
            while (true)
            {
                yield return new WaitForSeconds(secondsToSpawn);
                if(_coinPool.CurrentActiveAtMoment < _coinPool.MaxSize) 
                { 
                    Coin coin = _coinPool.Pool.Get();
                    coin.Spawner = this;
                    coin.gameObject.SetActive(true);
                }
            }
        }

