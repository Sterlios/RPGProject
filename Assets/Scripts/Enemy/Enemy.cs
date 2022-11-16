using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    [SerializeField] private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _health;
        gameObject.SetActive(false);
    }

    public void Init(Vector3 position)
    {
        gameObject.SetActive(true);
        transform.position = position;
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
