using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private Level[] _levels;
    [SerializeField] private Mine _mine;
    [SerializeField] private MinerData[] _minerDatas;
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private CameraBorder _cameraBorder;
    [SerializeField] private Transform _spawnPoint;

    private List<Miner> _miners;
    private int _currentLevel = 0;

    public static Game Instance;

    [HideInInspector] public UnityAction TwoOfAKindMinersAppeared;

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

    private void OnEnable()
    {
        _mine.Finished += OnMineFinished;
        Scores.Instance.FuelIsEmpty += OnFuelIsEmpty;
    }

    private void OnDisable()
    {
        _mine.Finished -= OnMineFinished;
        Scores.Instance.FuelIsEmpty -= OnFuelIsEmpty;
    }

    private void Start()
    {
        _miners = new List<Miner>();
        CreateCurrentLevel();
    }

    public void OnButtonContinue()
    {
        DeleteAllMiners();
        CreateCurrentLevel();
    }

    public void CreateCurrentLevel()
    {
        _cameraBorder.ResetPosition();
        _mine.CreateLevel(_levels[_currentLevel]);
    }

    public void OnButtonCreateMiner()
    {
        CreateMiner(_minerDatas[0], _spawnPoint.position);

        if (IsTwoOfAKindMinersAppear() == true)
        {
            TwoOfAKindMinersAppeared?.Invoke();
        }
    }

    private void CreateMiner(MinerData data, Vector3 position)
    {
        Miner miner = Instantiate(data.Miner);
        miner.transform.position = position;
        miner.name = "Miner " + data.Level;
        miner.Init(_mine, data);
        miner.Destroyed += OnMinerDestroyed;
        miner.MergeDone += OnMinerMerged;
        _miners.Add(miner);
    }

    public void OnButtonMergeMiners()
    {
        int maxLevel = _minerDatas.Length;

        for (int i = 0; i < maxLevel - 1; i++)
        {
            var miners = _miners.Where(miner => miner.Level == i && miner.MinerToMergeWith == null).ToList();

            if (miners.Count > 1)
            {
                miners[0].StartMerge(miners[1], _minerDatas[i + 1]);
                miners[1].StartMerge(miners[0]);

                return;
            }
        }
    }

    public bool IsTwoOfAKindMinersAppear()
    {
        int maxLevel = _minerDatas.Length;

        for (int i = 0; i < maxLevel - 1; i++)
        {
            var miners = _miners.Where(miner => miner.Level == i && miner.MinerToMergeWith == null).ToList();

            if (miners.Count > 1)
            {
                return true;
            }
        }

        return false;
    }

    private void OnMinerDestroyed(Miner miner, MinerData newMinerData)
    {
        miner.Destroyed -= OnMinerDestroyed;
        miner.MergeDone -= OnMinerMerged;
        _miners.Remove(miner);

        if (newMinerData != null)
        {
            CreateMiner(newMinerData, miner.transform.position);
            OnMinerMerged();
        }
    }

    private void OnMinerMerged()
    {
        if (IsTwoOfAKindMinersAppear() == true)
        {
            TwoOfAKindMinersAppeared?.Invoke();
        }
    }

    private void OnMineFinished()
    {
        _currentLevel++;

        if (_finishPanel != null)
            _finishPanel.SetActive(true);

        if (_gamePanel != null)
            _gamePanel.SetActive(false);
    }

    private void OnFuelIsEmpty()
    {

    }

    private void DeleteAllMiners()
    {
        foreach (var miner in _miners)
        {
            Destroy(miner.gameObject);
        }

        _miners.Clear();
    }
}
