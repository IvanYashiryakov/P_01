using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Miner))]
public class MergeDoneTransition : Transition
{
    private Miner _miner;
    private readonly float _targetDistance = 0.1f;

    private void Start()
    {
        _miner = GetComponent<Miner>();
    }

    private void Update()
    {
        if (NeedTransit == true)
            return;

        if (_miner.MinerToMergeWith == null || Vector3.Distance(transform.position, _miner.MinerToMergeWith.transform.position) < _targetDistance)
        {
            if (_miner.NextLevelMinerData == null)
            {
                Destroy(gameObject);
            }
            else
            {
                _miner.SetNextLevelMinerData();
            }
            NeedTransit = true;
        }
    }
}
