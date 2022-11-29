using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    [SerializeField] protected Player Target { get; private set; } = null;

    public virtual void Enter()
    {
        if (enabled)
            return;

        enabled = true;

        foreach (Transition transition in _transitions)
            transition.Activate();
    }

    public virtual void Exit()
    {
        if (!enabled)
            return;

        enabled = false;

        foreach (Transition transition in _transitions)
            transition.Deactivate();
    }

    public State GetNextState()
    {
        foreach (Transition transition in _transitions)
            if (transition.NeedTransit)
                return transition.TargetState;

        return null;
    }
}
