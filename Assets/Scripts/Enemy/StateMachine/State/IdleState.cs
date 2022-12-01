using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    [SerializeField] private float _minDuration;
    [SerializeField] private float _maxDuration;

    private float _duration;
    private float _time;

    public bool IsStay { get; private set; }

    private void Awake()
    {
        if (_minDuration == 0)
            _minDuration = 1;

        if (_minDuration > _maxDuration)
            _maxDuration = _minDuration + 1;
    }

    private void Update()
    {
        if (Target == null)
        {
            if (_time == 0)
            {
                _duration = Random.Range(_minDuration, _maxDuration);
                IsStay = true;
            }

            if (_time >= _duration)
            {
                _time = 0;
                IsStay = false;
                return;
            }

            _time += Time.deltaTime;
        }
    }
}
