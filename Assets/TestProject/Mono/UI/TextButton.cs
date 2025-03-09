using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestProject.Mono.UI
{
    [RequireComponent(typeof(Button))]
    public class TextButton : MonoBehaviour
    {
        private Color _defaultButtonColor;

        private Button _button;
        private TMP_Text _text;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _text = _button.GetComponentInChildren<TMP_Text>();

            _defaultButtonColor = _button.image.color;
        }

        public void SetActive(bool isActive)
        {
            _button.interactable = isActive;
            _button.image.color = isActive ? _defaultButtonColor : Color.clear;
            _text.alpha = isActive ? 1f : 0f;
        }
    }
}
