using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Scores : MonoBehaviour
{
    [SerializeField] private int _gold = 0;
    [SerializeField] private float _maxFuel;

    private float _currentFuel;

    public static Scores Instance;
    public int Gold => _gold;
    public float Fuel => _currentFuel;

    [HideInInspector] public UnityAction<int> GoldAmountChanged;
    [HideInInspector] public UnityAction<float, float> FuelAmountChanged;

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
        _currentFuel = _maxFuel;

        GoldAmountChanged?.Invoke(_gold);
        FuelAmountChanged?.Invoke(_currentFuel, _maxFuel);
    }

    public void AddFuel(float value)
    {
        _currentFuel += value;

        if (_currentFuel > _maxFuel)
            _currentFuel = _maxFuel;

        FuelAmountChanged?.Invoke(_currentFuel, _maxFuel);
    }

    public bool TryRemoveFuel(float value)
    {
        if (_currentFuel == 0)
            return false;

        if (value <= _currentFuel)
            _currentFuel -= value;
        else
            _currentFuel = 0;

        FuelAmountChanged?.Invoke(_currentFuel, _maxFuel);

        return true;
    }

    public void AddGold(int value)
    {
        _gold += value;
        GoldAmountChanged?.Invoke(_gold);
    }

    public void RemoveGold(int value)
    {
        if (value <= _gold)
        {
            _gold -= value;
            GoldAmountChanged?.Invoke(_gold);
        }
    }
}
