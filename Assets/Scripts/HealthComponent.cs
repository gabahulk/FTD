using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int Health;
    public HittableBehaviour HittableBehaviour;

    public Action Death;
    private void Awake()
    {
        HittableBehaviour.Hit += OnHit;
    }

    private void OnDestroy()
    {
        HittableBehaviour.Hit -= OnHit;
    }

    private void OnHit()
    {
        Health -= 1;
        if (Health > 0) return;
        Death?.Invoke();
        Destroy(gameObject);
    }
}
