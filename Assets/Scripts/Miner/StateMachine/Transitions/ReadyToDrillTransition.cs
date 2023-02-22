using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyToDrillTransition : Transition
{
    private void Update()
    {
        if (transform.position.x == Target.transform.position.x)
        {
            NeedTransit = true;
        }
    }
}
