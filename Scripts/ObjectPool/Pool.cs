using System;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace UnityExamples
{
    [Serializable]
    public class Pool<T> where T : MonoBehaviour, IPoolable<T>
    {
        private const int MAX_STOCK = 200;
        private const int DEFAULT_CAPACITY = 50;
        private const bool COLLECTION_CHECK = true;

        [SerializeField] private string mPoolName;
        [SerializeField] private T mPrefab;
        [SerializeField] private Transform mParent;
        private ObjectPool<T> _pool;

        public Pool(T prefab, Transform parent)
        {
            mPoolName = typeof(T).Name;
            mPrefab = prefab;
            mParent = parent;
            _pool = CreatePool(mPrefab);
        }
        private void Return(T poolable) => _pool.Release(poolable);
        public T Get() => _pool.Get();

        public ObjectPool<T> CreatePool(T prefab) => new(CreatePooledObject, OnTakeFromPool, OnReturnToPool, OnDestroyObject, COLLECTION_CHECK, MAX_STOCK, DEFAULT_CAPACITY);
        private T CreatePooledObject()
        {
            T instance = Object.Instantiate(mPrefab, Vector3.zero, Quaternion.identity, mParent);
            instance.Return += Return;
            instance.gameObject.SetActive(false);

            return instance;
        }
        private void OnTakeFromPool(T instance) => instance.gameObject.SetActive(true);
        private void OnReturnToPool(T instance) => instance.gameObject.SetActive(false);
        private void OnDestroyObject(T instance) => Object.Destroy(instance.gameObject);
    }
}
