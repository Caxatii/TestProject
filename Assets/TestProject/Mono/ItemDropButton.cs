using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextButton), typeof(Button))]
public class ItemDropButton : MonoBehaviour
{
    private Button _button;
    private TextButton _textButton;

    public event Action Clicked;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _textButton = GetComponent<TextButton>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClicked);
    }

    public void SetActive(bool isActive)
    {
        _textButton.SetActive(isActive);
    }

    private void OnClicked()
    {
        Clicked?.Invoke();
    }
}
