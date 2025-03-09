using System.Collections;
using UnityEngine;

namespace TestProject.Mono.Interactions
{
    public class DoorSlider : Interactable
    {
        [SerializeField] private float _openSpeed;
        [SerializeField] private float _autoCloseTime;
        [SerializeField] private Vector3 _slidePoint;

        private Transform _transform;
        private Coroutine _coroutine;

        private void Awake()
        {
            _transform = transform;
            _slidePoint += _transform.localPosition;
        }

        public override void Interact()
        {
            if (_coroutine != null)
                return;

            _coroutine = StartCoroutine(Slide(_slidePoint));
        }

        private IEnumerator Slide(Vector3 endPoint)
        {
            Vector3 startPoint = _transform.localPosition;

            yield return StartCoroutine(Move(endPoint));
            yield return new WaitForSeconds(_autoCloseTime);
            yield return StartCoroutine(Move(startPoint));

            _coroutine = null;
        }

        private IEnumerator Move(Vector3 nextPoint)
        {
            float step = _slidePoint.magnitude * _openSpeed;

            while (_transform.localPosition != nextPoint)
            {
                _transform.localPosition = Vector3.MoveTowards(_transform.position, nextPoint, step * Time.deltaTime);
                yield return null;
            }
        }
    }
}
