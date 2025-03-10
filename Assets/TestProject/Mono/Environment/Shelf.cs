using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TestProject.Mono.Environment
{
    public class Shelf : MonoBehaviour
    {
        [SerializeField] private List<ItemHolder> _holders;

        public bool HasFreeSpace =>
            _holders.All(holder => holder.IsHolding) == false;

        public void Transmit(Collectable collectable)
        {
            if (HasFreeSpace == false)
                throw new Exception("Not enough free space");
            
            _holders.Find(holder => holder.IsHolding == false).Take(collectable.Drop());
        }
    }
}
