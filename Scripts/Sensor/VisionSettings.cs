using UnityEngine;

namespace UnityExamples
{
    [CreateAssetMenu(fileName = "VisionSettings",menuName = "GameLoop/AI/Vision Settings")]
    public class VisionSettings : ScriptableObject
    {
        [Range(1, 100f)] public float radius;
        [Range(0, 360f)] public float angle;
        public Vector3 offset = new(0f, 0.9f, 0f);
        public FactionGroup targetGroup;
    }
}
