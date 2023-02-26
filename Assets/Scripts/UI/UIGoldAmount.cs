using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGoldAmount : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        Score.Instance.GoldAmountChanged += OnGoldAmountChanged;
    }

    private void OnDisable()
    {
        Score.Instance.GoldAmountChanged -= OnGoldAmountChanged;
    }

    private void OnGoldAmountChanged(int value)
    {
        _text.text = value.ToString();
    }
}
