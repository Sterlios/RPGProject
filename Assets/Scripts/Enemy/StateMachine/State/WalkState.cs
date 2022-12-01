using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _rotateSpeed;

    private int _animationHash;
    private Vector3 _targetPoint;
    private Spawn _spawn;
    private Vector3 _direction;
    private Quaternion _rotation;

    public bool IsWalk { get; private set; }

    private void Awake()
    {
        _targetPoint = Vector3.zero;
        _animationHash = Animator.StringToHash("IsWalk");
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
                StartWalk();

            transform.rotation = Quaternion.Lerp(transform.rotation, _rotation, _rotateSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, _targetPoint, _walkSpeed * Time.deltaTime);

            if (transform.position == _targetPoint)
                StopWalk();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.TryGetComponent<Ground>(out Ground _))
            StopWalk();
    }

    private void StartWalk()
    {
        _targetPoint = _spawn.GetPosition();
        IsWalk = true;
        StartAnimation(_animationHash);
        _direction = _targetPoint - transform.position;
        _rotation = Quaternion.LookRotation(_direction);
    }

    private void StopWalk()
    {
        _targetPoint = Vector3.zero;
        IsWalk = false;
        StopAnimation(_animationHash);
    }
}
