using TestProject.Mono.Environment;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TestProject.Mono.UI
{
    [RequireComponent(typeof(TextButton), typeof(Button))]
    public class ItemDropButton : MonoBehaviour
    {
        [Inject] private ItemHolder _itemHolder;
        
        private Button _button;
        private TextButton _textButton;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
            _textButton = GetComponent<TextButton>();
        }

        private void Start()
        {
            _textButton.SetActive(_itemHolder.IsHolding);
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClicked);
            _itemHolder.Dropped += OnDrop;
            _itemHolder.Took += OnTake;
        }
        
        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClicked);
            _itemHolder.Dropped -= OnDrop;
            _itemHolder.Took -= OnTake;
        }
        
        private void OnTake(Collectable obj)
        {
            _textButton.SetActive(true);
        }
        
        private void OnDrop(Collectable obj)
        {
            _textButton.SetActive(false);
        }

        private void OnClicked()
        {
            _itemHolder.Drop();
        }
    }
}
