using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeDoneState : State
{
    private Miner _miner;

    private void Start()
    {
        _miner = GetComponent<Miner>();

        if (_miner.NextLevelMinerData == null)
        {
            Destroy(gameObject);
        }
        else
        {
            _miner.SetNextLevelMinerData();
        }
    }
}
