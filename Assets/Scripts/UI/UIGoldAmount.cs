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
        OnGoldAmountChanged(Scores.Instance.Gold);
    }

    private void OnDisable()
    {
        Scores.Instance.GoldAmountChanged -= OnGoldAmountChanged;
    }

    private void OnGoldAmountChanged(float value)
    {
        _text.text = ((int)value).ToString();
    }
}
