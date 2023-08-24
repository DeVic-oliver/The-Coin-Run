namespace Assets.Scripts.Items
{
    using UnityEngine;
    using UnityEngine.Pool;
    
    public class CoinPool : MonoBehaviour
    {
        public IObjectPool<Coin> Pool { get; private set; }

        public readonly int MaxSize = 18;
        
        public int CurrentActiveAtMoment { get; private set; }

        private Coin _coin;

        private readonly bool _collectionCheck = true;


        public void InitPool(Coin coinPrefab)
        {
            _coin = coinPrefab;
            Pool = new ObjectPool<Coin>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, _collectionCheck);
        }

        private Coin CreatePooledItem()
        {
            Coin coin = Instantiate(_coin);
            coin.gameObject.SetActive(false);
            return coin;
        }

        void OnReturnedToPool(Coin system)
        {
            CurrentActiveAtMoment--;
            system.gameObject.SetActive(false);
        }

        void OnTakeFromPool(Coin system)
        {
            CurrentActiveAtMoment++;
            system.gameObject.SetActive(true);
        }

        void OnDestroyPoolObject(Coin system)
        {
            Destroy(system.gameObject);
        }
    }
}