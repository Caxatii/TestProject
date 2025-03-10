using System;
using TestProject.Mono.Player;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace TestProject.Mono.Interactions
{
    public class TouchRaycaster : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        
        [Inject] private FirstPersonCamera _camera;
        
        private MainActions _mainActions;

        public event Action<RaycastHit> Raycasted;

        private void Awake()
        {
            _mainActions = new();
        }

        private void OnEnable()
        {
            _mainActions.Enable();
            _mainActions.Touchscreen.SingleTouch.performed += OnTouched;
        }

        private void OnDisable()
        {
            _mainActions.Disable();
            _mainActions.Touchscreen.SingleTouch.performed -= OnTouched;
        }

        private void OnTouched(InputAction.CallbackContext context)
        {
            Ray ray = _camera.Camera.ScreenPointToRay(_mainActions.Touchscreen.TouchPosition.ReadValue<Vector2>());
            if(Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, _layerMask))
                Raycasted?.Invoke(hit);
        }
    }
}