using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    public abstract Collectable Collect();

    public abstract Collectable Drop();
}
