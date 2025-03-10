using System;
using System.Collections;
using UnityEngine;

namespace TestProject.Mono.Environment
{
    [RequireComponent(typeof(ItemDropper), typeof(GameObjectLerpMover))]
    public class ItemHolder : MonoBehaviour
    {
        [SerializeField] private float _pickupTime;

        [SerializeField] private Transform _itemHolding;
        [SerializeField] private Collectable _item;

        private ItemDropper _itemDropper;
        private ObstacleDetector _obstacleDetector ;
        private GameObjectLerpMover _gameObjectLerpMover;
        
        public event Action<Collectable> Took;
        public event Action<Collectable> Dropped;
        
        public bool IsHolding =>
            _item != null;

        private void Awake()
        {
            _itemDropper = GetComponent<ItemDropper>();
            _gameObjectLerpMover = GetComponent<GameObjectLerpMover>();

            TryGetComponent(out _obstacleDetector);
        }

        public void Take(Collectable collectable)
        {
            _item = collectable.Collect();
            StartCoroutine(TransmitItem());
        }

        public void Drop()
        {
            if(_item == null)
                throw new NullReferenceException("Item was null.");
            
            if(_obstacleDetector?.HasObstacleBetween(transform.position, _itemHolding.position) ?? false) 
                    return;
            
            _item.transform.SetParent(null);
            _itemDropper.Drop(_item.Drop());

            Dropped?.Invoke(_item);
            _item = null;
        }

        private IEnumerator TransmitItem()
        {
            yield return _gameObjectLerpMover.Move(_item.gameObject, _itemHolding, _pickupTime);

            _item.transform.SetParent(_itemHolding);
            Took?.Invoke(_item);
        }
    }
}
