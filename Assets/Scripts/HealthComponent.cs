using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int StartingHealth;
    public HittableBehaviour HittableBehaviour;
    public Action Death;
    public Action<int> HealthUpdate;
    
    
    private int _health;
    private void Awake()
    {
        _health = StartingHealth;
        HittableBehaviour.Hit += OnHit;
    }

    private void OnDestroy()
    {
        HittableBehaviour.Hit -= OnHit;
    }

    private void OnHit()
    {
        _health -= 1;
        HealthUpdate?.Invoke(_health);
        if (_health > 0) return;
        Death?.Invoke();
        Destroy(gameObject);
    }
}
