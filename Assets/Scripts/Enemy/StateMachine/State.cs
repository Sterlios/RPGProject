using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    public virtual void Enter()
    {
        if (enabled)
            return;

        enabled = true;

        foreach (Transition transition in _transitions)
            transition.enabled = true;
    }

    public virtual void Exit()
    {
        if (!enabled)
            return;

        enabled = false;

        foreach (Transition transition in _transitions)
            transition.enabled = false;
    }

    public State GetNextState()
    {
        foreach (Transition transition in _transitions)
            if (transition.NeedTransit)
                return transition.TargetState;

        return null;
    }
}
