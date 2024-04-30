using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UILevelView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _buttonImage;
    [SerializeField] private Button _button;
    [SerializeField] private Sprite _active, _inactive;

    private int _id = -1;

    public Action<int> Click;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        Click?.Invoke(_id);
    }

    public void Init(bool isActive, int id = -1)
    {
        _button.interactable = isActive;
        _buttonImage.sprite = isActive ? _active : _inactive;

        if (id != -1)
        {
            _id = id;
            _text.text = (id + 1).ToString();
        }
    }
}
