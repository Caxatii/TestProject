using System.Collections;
using UnityEngine;

namespace TestProject.Mono.Interactions
{
    public class DoorSlider : Interactable
    {
        [SerializeField] private float _openSpeed;
        [SerializeField] private float _autoCloseTime;
        [SerializeField] private Vector3 _slideDirection;

        private bool _isOpen;
        private Vector3 _startPosition;
        private Transform _transform;
        
        private Coroutine _autoClose;
        
        private void Awake()
        {
            _transform = transform;
            _slideDirection += _transform.localPosition;
            _startPosition = _transform.position;
        }

        private void Update()
        {
            Vector3 nextPoint = _isOpen ? _slideDirection : _startPosition;

            if(_transform.position != nextPoint)
                _transform.localPosition =
                    Vector3.MoveTowards(_transform.position, nextPoint, _openSpeed * Time.deltaTime);
        }

        public override void Interact()
        {
            _isOpen = true;

            if (_autoClose == null)
                _autoClose = StartCoroutine(AutoClose());
        }

        private IEnumerator AutoClose()
        {
            yield return new WaitForSeconds(_autoCloseTime);
            
            _isOpen = false;
            _autoClose = null;
        }
    }
}
