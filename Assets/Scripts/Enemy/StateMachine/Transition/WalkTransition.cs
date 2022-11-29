using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IdleState))]
public class WalkTransition : Transition
{
    private IdleState _idleState;

    private void Awake()
    {
        _idleState = GetComponent<IdleState>();
    }

    private void Update()
    {
        if (Target == null && !_idleState.IsStay)
            OpenTransit();
    }
}
