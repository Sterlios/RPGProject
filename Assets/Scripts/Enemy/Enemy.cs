using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _health;
        gameObject.SetActive(false);
    }

    public void Init(Vector3 position, Vector3 rotation)
    {
        _currentHealth = _health;

        transform.position = position;
        transform.eulerAngles = rotation;

        gameObject.SetActive(true);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
