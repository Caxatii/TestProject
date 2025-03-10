using System;
using UnityEngine;

namespace TestProject.Mono.Environment
{
    [RequireComponent(typeof(Collider), typeof(ItemHolder))]
    public class ItemHolderCollider : MonoBehaviour
    {
        private Collider _collider;
        private ItemHolder _itemHolder;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
            _itemHolder = GetComponent<ItemHolder>();
        }

        private void Start()
        {
            if(_itemHolder.IsHolding)
                OnTake(null);
            else
                OnDropped(null);
        }

        private void OnEnable()
        {
            _itemHolder.Dropped += OnDropped;
            _itemHolder.Took += OnTake;
        }

        private void OnDisable()
        {
            _itemHolder.Dropped -= OnDropped;
            _itemHolder.Took -= OnTake;
        }

        private void OnTake(Collectable obj)
        {
            _collider.enabled = true;
        }

        private void OnDropped(Collectable obj)
        {
            _collider.enabled = false;
        }
    }
}