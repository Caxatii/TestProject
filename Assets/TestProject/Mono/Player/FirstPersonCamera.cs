using UnityEngine;
using Zenject;

namespace TestProject.Mono.Player
{
    [RequireComponent(typeof(Camera))]
    public class FirstPersonCamera : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        
        public Camera Camera { get; private set; }
        
        [Inject]
        private void Construct(MainPlayer player)
        {
            transform.position = player.transform.position + _offset;
            transform.SetParent(player.transform);
            Camera = GetComponent<Camera>();
        }
    }
}
