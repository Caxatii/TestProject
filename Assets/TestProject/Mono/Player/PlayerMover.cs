using UnityEngine;

namespace TestProject.Mono.Player
{
    [RequireComponent(typeof(CharacterController), typeof(PlayerInputReader))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _speed;
    
        private CharacterController _characterController;
        private PlayerInputReader _playerInputReader;
    
        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _playerInputReader = GetComponent<PlayerInputReader>();
        }

        private void FixedUpdate()
        {
            Vector3 forward = _characterController.transform.forward * _playerInputReader.JoystickDirection.y;
            Vector3 right = _characterController.transform.right * _playerInputReader.JoystickDirection.x;

            _characterController.SimpleMove((forward + right) * _speed);
        }
    }
}
