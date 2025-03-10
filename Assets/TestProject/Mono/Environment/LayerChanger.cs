using UnityEngine;

namespace TestProject.Mono.Environment
{
    [RequireComponent(typeof(ItemHolder))]
    public class LayerChanger : MonoBehaviour
    {
        [SerializeField] private GameObject _layerPrefab;
        
        private int? _holdItemLayerIndex;
        private ItemHolder _itemHolder;

        private void Awake()
        {
            _itemHolder = GetComponent<ItemHolder>();
        }

        private void OnEnable()
        {
            _itemHolder.Took += OnTook;
            _itemHolder.Dropped += OnDropped;
        }
        
        private void OnDisable()
        {
            _itemHolder.Took -= OnTook;
            _itemHolder.Dropped -= OnDropped;
        }
        
        private void OnTook(Collectable collectable)
        {
            _holdItemLayerIndex = collectable.gameObject.layer;
            collectable.gameObject.layer = _layerPrefab.layer;
        }
        
        private void OnDropped(Collectable collectable)
        {
            collectable.gameObject.layer = _holdItemLayerIndex ?? 0;
        }
    }
}
