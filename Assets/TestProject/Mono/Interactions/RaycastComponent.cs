using UnityEngine;
using Zenject;

namespace TestProject.Mono.Interactions
{
    [RequireComponent(typeof(TouchRaycaster))]
    public abstract class RaycastComponent : MonoBehaviour
    {
        [SerializeField] protected float _maxDistance;
        
        [Inject] protected TouchRaycaster TouchRaycaster;
    }
}