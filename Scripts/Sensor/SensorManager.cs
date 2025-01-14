using UnityEngine;

namespace UnityExamples
{
  public class SensorManager : MonoBehaviour
  {
    [SerializeField] private LayerMask mTargetMask;
    [SerializeField] private LayerMask mObstructionMask;

    public readonly static LayerMask TargetMask;
    public readonly static LayerMask ObstructionMask;

    public void Awake()
    {
      TargetMask = mTargetMask;
      ObstructionMask = mObstructionMask;
    }
  }
}
