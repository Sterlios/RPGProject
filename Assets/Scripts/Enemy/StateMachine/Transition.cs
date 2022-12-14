using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    public State TargetState => _targetState;
    public bool NeedTransit { get; private set; }
    protected Player Target { get; private set; }

    public void Activate()
    {
        enabled = true;
        NeedTransit = false;
    }

    public void Deactivate()
    {
        enabled = false;
    }

    public void Init(Player target)
    {
        Target = target;
    }

    public void OpenTransit()
    {
        NeedTransit = true;
    }
}