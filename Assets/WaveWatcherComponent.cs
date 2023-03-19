using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveWatcherComponent : MonoBehaviour
{
    public WaveSpawnerComponent WaveSpawnerComponent;

    public Action<int> EnemiesSpawned;
    public Action EnemyDied;
    private void Awake()
    {
        WaveSpawnerComponent.WaveSpawn += OnWaveSpawn;
        WaveSpawnerComponent.WaveDelayStarted += OnWaveCountdownStarted;
    }

    private void OnDestroy()
    {
        WaveSpawnerComponent.WaveSpawn -= OnWaveSpawn;
        WaveSpawnerComponent.WaveDelayStarted = OnWaveCountdownStarted;
    }
    
    private void OnWaveCountdownStarted(int remainingTime)
    {
        Debug.Log($"Countdown started! Remaining Time is {remainingTime}");
    }

    private void OnWaveSpawn(WaveStatus status)
    {
        EnemiesSpawned?.Invoke(status.EnemiesHealthComponents.Count);
        foreach (var health in status.EnemiesHealthComponents)
        {
            void DeathHandler()
            {
                EnemyDied?.Invoke();
                health.Death -= DeathHandler;
            }
            health.Death += DeathHandler;
        }
    }
}
