using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTransition : Transition
{
    [SerializeField] private WaitState _waitState;

    void Update()
    {
        if (_waitState.PastTime > _waitState.WaitTime)
            NeedTransit = true;
    }
}
