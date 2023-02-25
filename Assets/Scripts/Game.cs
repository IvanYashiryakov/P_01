using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _minerPrefab;
    [SerializeField] private Mine _mine;
    [SerializeField] private MinerData[] _minerDatas;

    private int _minersCount = 1;
    private List<Miner> _miners;

    private void Start()
    {
        _miners = new List<Miner>();
    }

    public void OnButtonCreateMiner()
    {
        _minersCount++;
        var newMinerInstance = Instantiate(_minerPrefab);
        newMinerInstance.name = "Miner " + _minersCount;

        Miner miner = newMinerInstance.GetComponent<Miner>();
        miner.Init(_mine, _minerDatas[0]);
        miner.Destroyed += OnMinerDestroyed;
        _miners.Add(miner);
    }

    public void OnButtonMergeMiners()
    {
        int maxLevel = _minerDatas.Length;

        for (int i = 0; i < maxLevel - 1; i++)
        {
            var miners = _miners.Where(miner => miner.Level == i).ToList();

            if (miners.Count > 1)
            {
                miners[0].StartMerge(miners[1], _minerDatas[i + 1]);
                miners[1].StartMerge(miners[0]);

                break;
            }
        }
    }

    private void OnMinerDestroyed(Miner miner)
    {
        miner.Destroyed -= OnMinerDestroyed;
        _miners.Remove(miner);
    }
}
