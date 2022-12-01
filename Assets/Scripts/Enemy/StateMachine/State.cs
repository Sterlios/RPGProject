using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;
    
    private Animator _animator;

    protected Player Target { get; private set; }

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

    protected void StartAnimation(int hash)
    {
        InitAnimator();
        _animator.SetBool(hash, true);
    }

    protected void StopAnimation(int hash)
    {
        _animator.SetBool(hash, false);
    }

    private void InitAnimator()
    {
        if(_animator == null)
            _animator = GetComponent<Animator>();
    }
}
