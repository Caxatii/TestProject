using UnityEngine;

namespace TestProject.Mono.Environment
{
    public abstract class Collectable : MonoBehaviour
    {
        public abstract Collectable Collect();

        public abstract Collectable Drop();
    }
}
