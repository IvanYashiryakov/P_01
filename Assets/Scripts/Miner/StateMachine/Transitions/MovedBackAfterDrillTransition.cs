using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovedBackAfterDrillTransition : Transition
{
    private Vector3 _targetPosition;

    private void Update()
    {
        if (transform.position == _targetPosition)
            NeedTransit = true;
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
    }
}
