using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreDoneTransition : Transition
{
    private void Update()
    {
        if (Target == null)
            NeedTransit = true;
    }
}
