using TestProject.Mono.UI;
using UnityEngine;
using Zenject;

namespace TestProject.Mono.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerLook : MonoBehaviour
    {
        [SerializeField] private float _sensitivity;
        [SerializeField] private float _minAngle;
        [SerializeField] private float _maxAngle;
        
        [Inject] private FirstPersonCamera _camera;
        [Inject] private TouchZoneInputReader _touchZoneInput;
        [Inject] private CharacterController _characterController;

        private Vector3 _cameraRotation;

        private void Update()
        {
            RotateCharacter();
            RotateCamera();            
        }

        private void RotateCharacter()
        {
            Vector3 direction = Vector3.up * (_touchZoneInput.Direction.x * _sensitivity);

            _characterController.transform.Rotate(direction * Time.deltaTime);
        }

        private void RotateCamera()
        {
            _cameraRotation.x -= _touchZoneInput.Direction.y * _sensitivity * Time.deltaTime;
            _cameraRotation.x = Mathf.Clamp(_cameraRotation.x, _minAngle, _maxAngle);

            _camera.transform.localRotation = Quaternion.Euler(_cameraRotation);
        }
    }
}

