using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchRaycaster : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Camera _camera;

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

    private void Update()
    {
        //Debug.Log(_a.phase);
    }

    private void OnTouched(InputAction.CallbackContext context)
    {
        Ray ray = _camera.ScreenPointToRay(_mainActions.Touchscreen.TouchPosition.ReadValue<Vector2>());
        if(Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, _layerMask))
            Raycasted?.Invoke(hit);
    }
}