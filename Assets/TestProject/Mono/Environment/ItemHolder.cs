using System.Collections;
using TestProject.Mono.UI;
using UnityEngine;

namespace TestProject.Mono.Environment
{
    [RequireComponent(typeof(ItemDropper))]
    public class ItemHolder : MonoBehaviour
    {
        [SerializeField, Min(0.1f)] private float _pickupTime;

        [SerializeField] private ItemDropButton _dropButton;
        [SerializeField] private Transform _itemHoldingPosition;

        private Collectable _collectable;
        private ItemDropper _itemDropper;
        private int? _holdedItemLayerIndex;

        public bool IsHolding =>
            _collectable != null;

        private void Awake()
        {
            _itemDropper = GetComponent<ItemDropper>();
        }

        private void Start()
        {
            UpdateButton();
        }

        private void OnEnable()
        {
            _dropButton.Clicked += OnDropClicked;
        }

        private void OnDisable()
        {
            _dropButton.Clicked -= OnDropClicked;
        }

        public void Take(Collectable collectable)
        {
            _collectable = collectable;
            _holdedItemLayerIndex = _collectable.gameObject.layer;
            StartCoroutine(TransmitItem());
        }

        private void OnDropClicked()
        {
            _collectable.gameObject.layer = _holdedItemLayerIndex.Value;
            _collectable.transform.SetParent(null);
            _itemDropper.Drop(_collectable.Drop());

            _holdedItemLayerIndex = null;
            _collectable = null;
            UpdateButton();
        }

        private void UpdateButton()
        {
            _dropButton.SetActive(IsHolding);
        }

        private IEnumerator TransmitItem()
        {
            float time = 0;

            while(_collectable.transform.position != _itemHoldingPosition.position)
            {
                float percentComplete = time / _pickupTime;

                _collectable.transform.position = Vector3.Lerp(_collectable.transform.position, _itemHoldingPosition.position, percentComplete);
                _collectable.transform.rotation = Quaternion.Lerp(_collectable.transform.rotation, _itemHoldingPosition.rotation, percentComplete);

                time += Time.deltaTime;
                yield return null;
            }

            _collectable.gameObject.layer = _itemHoldingPosition.gameObject.layer;
            _collectable.transform.SetParent(_itemHoldingPosition);
            UpdateButton();
        }
    }
}
