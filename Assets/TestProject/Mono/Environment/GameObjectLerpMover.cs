using System.Collections;
using UnityEngine;

namespace TestProject.Mono.Environment
{
    public class GameObjectLerpMover : MonoBehaviour
    {
        public IEnumerator Move(GameObject gameObject, Transform endPoint, float time)
        {
            float passedTime = 0;
            
            if (time <= 0)
            {
                gameObject.transform.position = endPoint.position;
                gameObject.transform.rotation = endPoint.rotation;
            }
            
            while(gameObject.transform.position != endPoint.position)
            {
                float percentComplete = passedTime / time;

                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint.position, percentComplete);
                gameObject.transform.localRotation = Quaternion.Lerp(gameObject.transform.rotation, endPoint.rotation, percentComplete);

                passedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}
