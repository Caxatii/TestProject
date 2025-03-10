using TestProject.Mono.Environment;
using UnityEngine;
using Zenject;

namespace TestProject.Mono.Interactions
{
    [RequireComponent(typeof(TouchRaycaster), typeof(ItemHolder))]
    public class ItemPlacer : RaycastComponent
    {
        [Inject] private ItemHolder _itemHolder;

        private void OnEnable()
        {
            TouchRaycaster.Raycasted += OnRaycast;
        }

        private void OnDisable()
        {
            TouchRaycaster.Raycasted += OnRaycast;
        }

        private void OnRaycast(RaycastHit hit)
        {
            if(hit.distance > _maxDistance || _itemHolder.IsHolding == false)
                return;
            
            if(hit.collider.TryGetComponent(out Shelf shelf) == false || shelf.HasFreeSpace == false)
                return;

            _itemHolder.Dropped += shelf.Transmit;
            _itemHolder.Drop();
            _itemHolder.Dropped -= shelf.Transmit;
        }
    }
}
