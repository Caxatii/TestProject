using TestProject.Mono.Environment;
using UnityEngine;
using Zenject;

namespace TestProject.Mono.Interactions
{
    [RequireComponent(typeof(ItemHolder))]
    public class ItemCollector : RaycastComponent
    {
        [Inject] private ItemHolder _itemHolder;

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
            if(_itemHolder.IsHolding || hit.distance > _maxDistance) 
                return;

            if (hit.collider.TryGetComponent(out Collectable collectable)) 
                _itemHolder.Take(collectable.Collect());
        }
    }
}
