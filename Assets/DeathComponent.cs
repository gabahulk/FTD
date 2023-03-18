using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathComponent : MonoBehaviour
{
    public HealthComponent HealthComponent;

    private void Awake()
    {
        HealthComponent.Death += OnDeath;
    }

    private void OnDestroy()
    {
        HealthComponent.Death -= OnDeath;
    }

    private void OnDeath()
    {
        Destroy(gameObject);
    }
}
