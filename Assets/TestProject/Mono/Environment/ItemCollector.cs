using TestProject.Mono.Interactions;
using UnityEngine;

namespace TestProject.Mono.Environment
{
    [RequireComponent(typeof(TouchRaycaster), typeof(ItemHolder))]
    public class ItemCollector : MonoBehaviour
    {
        [SerializeField] private float _maxDistance;

        private TouchRaycaster _raycaster;
        private ItemHolder _itemHolder;

        private void Awake()
        {
            _raycaster = GetComponent<TouchRaycaster>();
            _itemHolder = GetComponent<ItemHolder>();
        }

        private void OnEnable()
        {
            _raycaster.Raycasted += OnRaycasted;
        }

        private void OnDisable()
        {
            _raycaster.Raycasted -= OnRaycasted;
        }

        private void OnRaycasted(RaycastHit hit)
        {
            if(_itemHolder.IsHolding || hit.distance > _maxDistance) 
                return;

            if (hit.collider.TryGetComponent(out Collectable collectable)) 
                _itemHolder.Take(collectable.Collect());
        }
    }
}
