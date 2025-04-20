using UnityEngine;

namespace UnityExamples
{
    public interface IPoolable<T> where T : MonoBehaviour
    {
        delegate void ReturnCallback(T instance);
        ReturnCallback Return { get; set; }
    }
}
