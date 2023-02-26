using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private int _goldAmount = 0;

    public static Score Instance;
    public int GoldAmount => _goldAmount;

    [HideInInspector] public UnityAction<int> GoldAmountChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GoldAmountChanged?.Invoke(_goldAmount);
    }

    public void AddGold(int value)
    {
        _goldAmount += value;
        GoldAmountChanged?.Invoke(_goldAmount);
    }

    public void RemoveGold(int value)
    {
        if (value <= _goldAmount)
        {
            _goldAmount -= value;
            GoldAmountChanged?.Invoke(_goldAmount);
        }
    }
}
