using UnityEngine;

namespace TestProject.Mono.Environment
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Item : Collectable
    {
        private Collider _collider;
        private Rigidbody _rigidbody;
        
        private bool _defaultIsKinematic;
        private bool _defaultIsEnabledCollider;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
            
            _defaultIsKinematic = _rigidbody.isKinematic;
            _defaultIsEnabledCollider = _collider.enabled;
        }

        public override Collectable Collect()
        {
            _rigidbody.isKinematic = true;
            _collider.enabled = false;
            return this;
        }

        public override Collectable Drop()
        {
            _rigidbody.isKinematic = _defaultIsKinematic;
            _collider.enabled = _defaultIsEnabledCollider;
            return this;
        }
    }
}
