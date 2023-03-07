using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGoldAmount : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        Scores.Instance.GoldAmountChanged += OnGoldAmountChanged;
    }

    private void OnDisable()
    {
        Scores.Instance.GoldAmountChanged -= OnGoldAmountChanged;
    }

    private void OnGoldAmountChanged(int value)
    {
        _text.text = value.ToString();
    }
}
