using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    [SerializeField] private float _speed;

    [SerializeField] private Vector3 _targetPoint;
    [SerializeField] private Spawn _spawn;

    public bool IsWalk { get; private set; }

    private void Awake()
    {
        _targetPoint = Vector3.zero;
    }

    private void Start()
    {
        _spawn = GetComponentInParent<Spawn>();
    }

    private void Update()
    {
        if (Target == null)
        {
            if (_targetPoint == Vector3.zero)
            {
                _targetPoint = _spawn.GetPosition();
                IsWalk = true;
            }

            transform.position = Vector3.MoveTowards(transform.position, _targetPoint, _speed * Time.deltaTime);

            if (transform.position == _targetPoint)
            {
                _targetPoint = Vector3.zero;
                IsWalk = false;
            }
        }
    }
}
