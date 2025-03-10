using UnityEngine;

namespace TestProject.Mono.Environment
{
    public class ItemDropper : MonoBehaviour
    {
        [SerializeField] private float _dropForwardForce;
        [SerializeField] private float _dropUpForce;
        [SerializeField] private Transform _dropPoint;
        
        public void Drop(Collectable collectable)
        {
            if(_dropForwardForce == 0 && _dropUpForce == 0)
                return;
            
            if (collectable.TryGetComponent(out Rigidbody rigidbody) == false)
                return;
            
            Vector3 forward = _dropPoint.forward * _dropForwardForce;
            Vector3 up = _dropPoint.up * _dropUpForce;

            rigidbody.AddForce(forward + up, ForceMode.Impulse);
        }
    }
}
