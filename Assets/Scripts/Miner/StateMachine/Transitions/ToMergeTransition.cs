using UnityEngine;

public class ToMergeTransition : Transition
{
    [SerializeField] private StateMachine _stateMachine;

    private void Update()
    {
        if (NeedTransit == false && _stateMachine.NeedMerge == true)
        {
            NeedTransit = true;

            if (Target != null)
            {
                Target.SetBusy(false);
                _stateMachine.ResetTarget();
            }

            //_stateMachine.MergeTransitDone();
        }
    }
}
