using TestProject.Mono;
using UnityEngine;

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
        Vector3 direction = new Vector3(_playerInputReader.JoystickDirection.x, 0, _playerInputReader.JoystickDirection.y);
        _characterController.SimpleMove(direction * _speed);
    }
}
