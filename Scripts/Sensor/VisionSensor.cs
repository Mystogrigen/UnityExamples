using System;
using System.Collections;
using UnityEngine;

namespace UnityExamples
{
    public class VisionSensor : MonoBehaviour
    {
        [field: SerializeField] public bool canSeeTarget { get; private set; }
        [field: SerializeField] public Health target { get; private set; }
        
        [SerializeField] private VisionSettings mSettings;
        [SerializeField] private Collider[] mRangeCheck = new Collider[20];
        
        public VisionSettings settings => mSettings;
        
        private Vector3 GetOffset() =>transform.position + mSettings.offset; 
        
        private LayerMask _targetMask;
        private LayerMask _obstructionMask;

        private const float DELAY = 0.1f;
        
        private void Start()
        {
            _targetMask = _core.GetVisionTargetMask();
            _obstructionMask = _core.GetVisionObstructionMask();

            StartCoroutine(VisionRoutine());
        }

        private IEnumerator VisionRoutine()
        {
            while (true)
            {
                yield return Helpers.GetWaitForSeconds(DELAY);

                FieldOfViewCheck();
            }
        }

        private void FieldOfViewCheck()
        {
            Array.Clear(mRangeCheck, 0, mRangeCheck.Length);
            
            var size = Physics.OverlapSphereNonAlloc(transform.position, mSettings.radius, mRangeCheck, _targetMask);

            if (size != 0)
            {
                Health result = SearchResults(size);

                if (result is not null)
                {
                    target = result;
                    canSeeTarget = true;
                }
                else
                {
                    canSeeTarget = false;
                    target = null;
                }
            }
            else
            {
                canSeeTarget = false;
                target = null;
            }
        }

        private Health SearchResults(int size)
        {
            for (int i = 0; i < size; i++)
            {
                Transform currentTarget = mRangeCheck[i].transform;

                if (currentTarget.TryGetComponent(out Health targetHealth))
                {
                    if (targetHealth.factionGroup != mSettings.targetGroup && mSettings.targetGroup != FactionGroup.Insane)
                        continue;
                    
                    Vector3 direction = (targetHealth.GetOffset() - GetOffset()).normalized;
                    
                    if (Vector3.Angle(transform.forward, direction) < mSettings.angle / 2)
                    {
                        float distance = Vector3.Distance(GetOffset(), targetHealth.GetOffset());

                        if (!Physics.Raycast(GetOffset(), direction, distance, _obstructionMask))
                            return targetHealth;
                    }
                }
            }

            return null;
        }
    }
}
