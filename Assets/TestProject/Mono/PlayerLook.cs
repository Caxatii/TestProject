using System;
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

        private float _cameraRotation;
        private CharacterController _characterController;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            RotateCharacter();
            RotateCamera();
            
            ClampCameraAngle();
        }

        private void RotateCharacter()
        {
            Vector3 rotationX = Vector3.right * _saveZoneInput.Direction * _sensitivity;

            _characterController.transform.Rotate(rotationX * Time.fixedDeltaTime);
        }

        private void RotateCamera()
        {
            Vector3 rotationY = Vector3.up * _saveZoneInput.Direction * _sensitivity;

            _camera.transform.Rotate(rotationY * Time.fixedDeltaTime);
        }
        
        private void ClampCameraAngle()
        {
            Vector3 clamped = _camera.transform.rotation.eulerAngles;
            
            clamped.x = Mathf.Clamp(clamped.x, _minAngle, _maxAngle);
            
            _camera.transform.rotation = Quaternion.Euler(clamped);
        }
    }
}
