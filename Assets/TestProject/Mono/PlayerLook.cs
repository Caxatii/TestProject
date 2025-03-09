using UnityEngine;

namespace TestProject.Mono
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerLook : MonoBehaviour
    {
        [SerializeField] private float _sensitivity;
        [SerializeField] private float _minAngle;
        [SerializeField] private float _maxAngle;
        
        [SerializeField] private Camera _camera;
        [SerializeField] private SaveZoneInputReader _saveZoneInput;

        private Vector3 _cameraRotation;
        private CharacterController _characterController;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            RotateCharacter();
            RotateCamera();            
        }

        private void RotateCharacter()
        {
            Vector3 direction = Vector3.up * _saveZoneInput.Direction.x * _sensitivity;

            _characterController.transform.Rotate(direction * Time.deltaTime);
        }

        private void RotateCamera()
        {
            _cameraRotation.x -= _saveZoneInput.Direction.y * _sensitivity * Time.deltaTime;
            _cameraRotation.x = Mathf.Clamp(_cameraRotation.x, _minAngle, _maxAngle);

            _camera.transform.localRotation = Quaternion.Euler(_cameraRotation);
        }
    }
}
