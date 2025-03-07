using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

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
            Debug.Log(Direction);
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
