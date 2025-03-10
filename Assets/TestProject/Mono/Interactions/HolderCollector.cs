using TestProject.Mono.Environment;
using UnityEngine;
using Zenject;

namespace TestProject.Mono.Interactions
{
    [RequireComponent(typeof(TouchRaycaster), typeof(ItemHolder))]
    public class HolderCollector : RaycastComponent
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
            if(hit.distance > _maxDistance || _itemHolder.IsHolding)
                return;
            
            if(hit.collider.TryGetComponent(out ItemHolder holder) == false || holder.IsHolding == false)
                return;
            
            holder.Dropped += OnDropped;
            holder.Drop();
            holder.Dropped -= OnDropped;
        }

        private void OnDropped(Collectable collectable)
        {
            _itemHolder.Take(collectable);
        }
    }
}
