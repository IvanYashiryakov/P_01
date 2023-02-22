using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Miner))]
public class FindOreTransition : Transition
{
    private Mine _mine;
    private StateMachine _stateMachine;

    private void Start()
    {
        _mine = GetComponent<Miner>().Mine;
        _stateMachine = GetComponent<StateMachine>();
    }

    private void Update()
    {
        var ore = _mine.TryGetNearestFreeOre(transform.position);

        if (ore != null)
        {
            _stateMachine.SetTarget(ore);
            NeedTransit = true;
        }
    }
}
