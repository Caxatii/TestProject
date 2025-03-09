using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Item : Collectable
{
    private Rigidbody _rigidbody;
    private bool _defaultIsKinematic;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _defaultIsKinematic = _rigidbody.isKinematic;
    }

    public override Collectable Collect()
    {
        _rigidbody.isKinematic = true;
        return this;
    }

    public override Collectable Drop()
    {
        _rigidbody.isKinematic = _defaultIsKinematic;
        return this;
    }
}
