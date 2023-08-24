namespace Assets.Scripts.Items
{
    using Photon.Pun;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [RequireComponent(typeof(CoinPool))]
    public class CoinSpawner : MonoBehaviourPun
    {
        [SerializeField] private Coin _coin;
        [SerializeField] private List<MinMaxCoordinates> _coordinatesToSpawn;
        
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
            float secondsToSpawn = 0.8f;
            while (true)
            {
                yield return new WaitForSeconds(secondsToSpawn);
                if (_coinPool.CurrentActiveAtMoment < _coinPool.MaxSize)
                {
                    Vector3 randomPosition = GetRandomCoordinateYoSpawn();
                    photonView.RPC("GetCoinFromPoolThenActiveIt", RpcTarget.All, randomPosition);
                }
            }
        }

        [PunRPC]
        private void GetCoinFromPoolThenActiveIt(Vector3 position)
        {
            Coin coin = _coinPool.Pool.Get();
            
            if(coin.Spawner == null)
                coin.Spawner = this;

            
            coin.SetPosition(position);
            coin.gameObject.SetActive(true);
        }

        private Vector3 GetRandomCoordinateYoSpawn()
        {
            int index = Random.Range(0, _coordinatesToSpawn.Count);

            float minX = GetMinCoordinatesFrom(index).x;
            float maxX = GetMaxCoordinatesFrom(index).x;

            float minY = GetMinCoordinatesFrom(index).y;
            float maxY = GetMaxCoordinatesFrom(index).y;

            float minZ = GetMinCoordinatesFrom(index).z;
            float maxZ = GetMaxCoordinatesFrom(index).z;

            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            float randomZ = Random.Range(minZ, maxZ);

            return new Vector3(randomX, randomY, randomZ);
        }

        private Vector3 GetMinCoordinatesFrom(int index)
        {
            return _coordinatesToSpawn[index].MinCoord;
        }

        private Vector3 GetMaxCoordinatesFrom(int index)
        {
            return _coordinatesToSpawn[index].MaxCoord;
        }

    }

    [System.Serializable]
    public class MinMaxCoordinates
    {
        public Vector3 MinCoord;
        public Vector3 MaxCoord;
    }
}