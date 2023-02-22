using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected Ore Target { get; private set; }

    public State TargetState => _targetState;
    public bool NeedTransit { get; protected set; }

    private void OnEnable()
    {
        NeedTransit = false;
    }

    public void Init(Ore target)
    {
        Target = target;
    }
}
