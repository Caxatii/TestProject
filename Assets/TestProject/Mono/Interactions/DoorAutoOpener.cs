using System.Collections.Generic;
using UnityEngine;

namespace TestProject.Mono.Interactions
{
    [RequireComponent(typeof(Collider))]
    public class DoorAutoOpener : MonoBehaviour
    {
        [SerializeField] private DoorSlider _doorSlider;

        private List<Collider> _cashedCollisions = new();

        private void Update()
        {
            if (_cashedCollisions.Count > 0)
                _doorSlider.Interact();
        }

        private void OnTriggerEnter(Collider other)
        {
            _cashedCollisions.Add(other);
        }

        private void OnTriggerExit(Collider other)
        {
            _cashedCollisions.Remove(other);
        }
    }
}
