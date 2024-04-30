using UnityEngine;
using UnityEngine.Events;

public class Scores : MonoBehaviour
{
    [SerializeField] private float _gold;
    [SerializeField] private float _maxFuel;
    [SerializeField] private float _fuelBuyingRate;
    [SerializeField] private float _priceIncreaseRate;
    [SerializeField] private int _startMinerPrice;
    [SerializeField] private int _startMergePrice;

    private float _currentFuel;

    public static Scores Instance;
    public float Gold => _gold;
    public float Fuel => _currentFuel;
    public float PriceIncreaseRate => _priceIncreaseRate;
    public bool IsFuelMax => _currentFuel >= _maxFuel;
    public int StartMinerPrice => _startMinerPrice;
    public int StartMergePrice => _startMergePrice;

    [HideInInspector] public UnityAction<float> GoldAmountChanged;
    [HideInInspector] public UnityAction<float, float> FuelAmountChanged;
    [HideInInspector] public UnityAction FuelIsEmpty;

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
        _maxFuel = SaveManager.Instance.MaxFuel != -1 ? SaveManager.Instance.MaxFuel : _maxFuel;
        _gold = SaveManager.Instance.Gold != -1 ? SaveManager.Instance.Gold : _gold;

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

        if (_currentFuel == 0)
            FuelIsEmpty?.Invoke();

        return true;
    }

    public void AddGold(float value)
    {
        _gold += value;
        GoldAmountChanged?.Invoke(_gold);
    }

    public bool RemoveGold(float value)
    {
        if (value <= _gold)
        {
            _gold -= value;
            GoldAmountChanged?.Invoke(_gold);
            return true;
        }

        return false;
    }

    public void ButtonBuyFuel()
    {
        AddFuel(_maxFuel * _fuelBuyingRate);
    }

    public void RefillFuel()
    {
        AddFuel(_maxFuel);
    }
}
