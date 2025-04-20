using UnityEngine;

namespace UnityExamples
{
    public class ExamplePoolable : MonoBehaviour, IPoolable<ExamplePoolable>
    {
        public IPoolable<ExamplePoolable>.ReturnCallback Return { get; set; }

        [SerializeField] private Rigidbody mRigidBody;


        private void OnDisable()
        {
            mRigidBody.position = Vector3.zero;
            mRigidBody.rotation = Quaternion.identity;
            
            mRigidBody.angularVelocity = Vector3.zero;
            mRigidBody.linearVelocity = Vector3.zero;
            
            Return(this);
        }
    }
}
