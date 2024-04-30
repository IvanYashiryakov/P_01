using System.Collections;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;
    [SerializeField] private State _currentState;
    [SerializeField] private Miner _miner;
    [SerializeField] private Ore _target;

    private float _startDelay = 0.33f;
    private bool _needMerge;

    public State Current => _currentState;
    public Ore Target => _target;
    public bool NeedMerge => _needMerge;

    private void OnEnable()
    {
        _miner.MergeStarted += OnMerge;
    }

    private void OnDisable()
    {
        _miner.MergeStarted -= OnMerge;
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_startDelay);
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();

        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    public void SetTarget(Ore target)
    {
        _target = target;
    }

    public void ResetTarget()
    {
        _target = null;
    }

    public void MergeTransitDone()
    {
        _needMerge = false;
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;

        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }

    private void OnMerge()
    {
        _needMerge = true;
    }
}
