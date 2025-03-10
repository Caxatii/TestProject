using UnityEngine;

namespace TestProject.Mono.Interactions
{
    [RequireComponent(typeof(TouchRaycaster))]
    public class RaycastInteraction : RaycastComponent
    {
        private void OnEnable()
        {
            TouchRaycaster.Raycasted += OnRaycast;
        }

        private void OnDisable()
        {
            TouchRaycaster.Raycasted -= OnRaycast;
        }

        private void OnRaycast(RaycastHit hit)
        {
            if(hit.distance > _maxDistance || hit.collider == null) 
                return;

            if(hit.collider.TryGetComponent(out Interactable interactable))
                interactable.Interact();
        }
    }
}
