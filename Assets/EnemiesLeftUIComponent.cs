using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemiesLeftUIComponent : MonoBehaviour
{
    public WaveWatcherComponent WatcherComponent;
    public TMP_Text EnemiesLeftLabel;

    private int _totalEnemies;

    private void Awake()
    {
        WatcherComponent.EnemiesSpawned += OnEnemiesSpawned;
        WatcherComponent.EnemyDied += OnEnemyDied;
    }
    private void OnDestroy()
    {
        WatcherComponent.EnemiesSpawned -= OnEnemiesSpawned;
        WatcherComponent.EnemyDied -= OnEnemyDied;
    }
    
    private void OnEnemyDied()
    {
        _totalEnemies--;
        EnemiesLeftLabel.text = $"Enemies Left: {_totalEnemies}";
    }

    private void OnEnemiesSpawned(int quantity)
    {
        _totalEnemies = quantity;
        EnemiesLeftLabel.text = $"Enemies Left: {_totalEnemies}";
    }
}
