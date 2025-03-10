using UnityEngine;

namespace TestProject.Mono.Environment
{
    public class ObstacleDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _obstacleLayerMask;

        public bool HasObstacleBetween(Vector3 firstPoint, Vector3 secondPoint)
        {
            Vector3 direction = secondPoint - firstPoint;
            
            if(direction.magnitude == 0)
                return false;
            
            return Physics.Raycast(firstPoint, direction.normalized, direction.magnitude, _obstacleLayerMask);
        }
    }
}