using UnityEngine;
using UnityEngine.EventSystems;

namespace TestProject.Mono
{
    public class SaveZoneInputReader : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Vector2 _direction;
        private PointerEventData _pointerEventData;
        
        public Vector2 Direction => 
            _direction;
        
        private void Update()
        {
            _direction = _pointerEventData?.delta ?? Vector2.zero;
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
