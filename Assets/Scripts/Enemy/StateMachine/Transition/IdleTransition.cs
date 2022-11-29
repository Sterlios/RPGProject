using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WalkState))]
public class IdleTransition : Transition
{
    private WalkState _walkState;

    private void Awake()
    {
        _walkState = GetComponent<WalkState>();
    }

    private void Update()
    {
        if (Target == null && !_walkState.IsWalk)
            OpenTransit();
    }
}
