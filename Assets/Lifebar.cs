using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifebar : MonoBehaviour
{
    public Slider Slider;

    public HealthComponent HealthComponent;

    private void Awake()
    {
        HealthComponent.HealthUpdate += OnHealthUpdate;
        Slider.maxValue = HealthComponent.StartingHealth;
        Slider.value = Slider.maxValue;
    }

    private void OnDestroy()
    {
        HealthComponent.HealthUpdate -= OnHealthUpdate;
    }

    private void OnHealthUpdate(int value)
    {
        Slider.value = value;
    }
}
