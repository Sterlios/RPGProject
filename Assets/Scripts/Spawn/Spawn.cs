using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private Enemy _template;
    [SerializeField] private float _delay;

    private const float MaxAngle = 360;
    private float _afterDyingTime;
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = Instantiate(_template, transform);
        _afterDyingTime = _delay;
    }

    private void Update()
    {
        if (_enemy.gameObject.activeSelf)
            return;

        _afterDyingTime += Time.deltaTime;

        if (_afterDyingTime >= _delay)
        {
            float distance = Random.Range(0, _radius);
            float angle = Random.Range(0, MaxAngle);

            Vector3 rotation = new Vector3(0, Random.Range(0, MaxAngle), 0);
            Vector3 position = new Vector3(CalculatePositionX(distance, angle), transform.position.y, CalculatePositionZ(distance, angle));

            _enemy.Init(position, rotation);

            _afterDyingTime = 0;
        }
    }

    private float CalculatePositionX(float distance, float angle) 
        => Mathf.Cos(angle) * distance + transform.position.x;

    private float CalculatePositionZ(float distance, float angle) 
        => Mathf.Sin(angle) * distance + transform.position.z;
}
