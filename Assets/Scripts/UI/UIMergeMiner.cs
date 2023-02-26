using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMergeMiner : MonoBehaviour
{
    [SerializeField] private int _price = 200;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _buttonText = "Merge Miners";

    private void OnEnable()
    {
        Score.Instance.GoldAmountChanged += OnGoldAmountChanged;
        Game.Instance.TwoOfAKindMinersIsAppear += OnTwoOfAKindMinersIsAppear;
        _button.onClick.AddListener(OnButtonClick);
        _text.text = _buttonText + "\n" + _price;
    }

    private void OnDisable()
    {
        Score.Instance.GoldAmountChanged -= OnGoldAmountChanged;
        Game.Instance.TwoOfAKindMinersIsAppear -= OnTwoOfAKindMinersIsAppear;
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Score.Instance.RemoveGold(_price);
        _price = (int)(_price * 1.5f);
        _text.text = _buttonText + "\n" + _price;
    }

    private void OnTwoOfAKindMinersIsAppear()
    {
        if (Score.Instance.GoldAmount >= _price)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }

    private void OnGoldAmountChanged(int value)
    {
        if (value >= _price && Game.Instance.IsTwoOfAKindMinersIsAppear() == true)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }
}
