using UnityEngine;
using UnityEngine.EventSystems;

namespace TestProject.Mono.UI
{
    public class TouchZoneInputReader : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private PointerEventData _pointerEventData;
        
        public Vector2 Direction { get; private set; }

        private void Update()
        {
            Direction = _pointerEventData?.delta ?? Vector2.zero;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _pointerEventData = eventData;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _pointerEventData = null;
        }
    }
}
