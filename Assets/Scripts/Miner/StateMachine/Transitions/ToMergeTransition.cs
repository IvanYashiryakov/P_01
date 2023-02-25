using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMergeTransition : Transition
{
    [SerializeField] private StateMachine _stateMachine;

    private void Update()
    {
        if (_stateMachine.NeedMerge == true)
        {
            NeedTransit = true;

            if (Target != null)
            {
                Target.SetBusy(false);
            }

            _stateMachine.MergeTransitDone();
        }
    }
}
