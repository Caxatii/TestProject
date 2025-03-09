using UnityEngine;

[RequireComponent(typeof(TouchRaycaster))]
public class RaycastInteraction : MonoBehaviour
{
    [SerializeField] private float _maxDistance;

    private TouchRaycaster _raycaster;

    private void Awake()
    {
        _raycaster = GetComponent<TouchRaycaster>();
    }

    private void OnEnable()
    {
        _raycaster.Raycasted += OnRaycasted;
    }

    private void OnDisable()
    {
        _raycaster.Raycasted -= OnRaycasted;
    }

    private void OnRaycasted(RaycastHit hit)
    {
        if(hit.distance > _maxDistance || hit.collider == null) 
            return;

        if(hit.collider.TryGetComponent(out Interactable interactable))
            interactable.Interact();
    }
}
