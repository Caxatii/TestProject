using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    [SerializeField] private float _dropForwardForce;
    [SerializeField] private float _dropUpForce;

    [SerializeField] protected Transform _dropPoint;

    public void Drop(Collectable collectable)
    {
        if (collectable.TryGetComponent(out Rigidbody rigidbody))
        {
            Vector3 forward = _dropPoint.forward * _dropForwardForce;
            Vector3 up = _dropPoint.up * _dropUpForce;

            rigidbody.AddForce(forward + up, ForceMode.Impulse);
        }
    }
}
