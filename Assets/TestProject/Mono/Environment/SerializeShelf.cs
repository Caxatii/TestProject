using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject.Mono.Environment
{
    [RequireComponent(typeof(Shelf))]
    public class SerializeShelf : MonoBehaviour
    {
        [SerializeField] private List<Collectable> _itemsPrefabs;
        
        private Shelf _shelf;

        private void Start()
        {
            _shelf = GetComponent<Shelf>();
            Vector3 spawnPoint = _shelf.transform.position;
            
            foreach (Collectable item in _itemsPrefabs)
            {
                if(_shelf.HasFreeSpace == false)
                    throw new Exception($"Can't transmit item {item}, no free space");

                _shelf.Transmit(Instantiate(item, spawnPoint, Quaternion.identity));
            }
        }
    }
}
