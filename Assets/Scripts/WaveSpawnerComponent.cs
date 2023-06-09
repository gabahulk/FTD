using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

public struct WaveStatus
{
    public readonly List<CircularSpawner.Direction> WaveDirections;
    public readonly List<HealthComponent> EnemiesHealthComponents;

    public WaveStatus(List<CircularSpawner.Direction> directions, List<HealthComponent> healthComponents)
    {
        WaveDirections = directions;
        EnemiesHealthComponents = healthComponents;
    }
}

public class WaveSpawnerComponent : MonoBehaviour
{
    public CircularSpawner Spawner;
    public List<WaveConfig> WaveConfigs;
    public int TotalGameTimeInMinutes;
    public WaveWatcherComponent WatcherComponent;

    public Action<WaveStatus> WaveSpawn;
    public Action<int, int> WaveDelayStarted;
    
    private int _totalTimeInMilliseconds;
    private int _currentTimeInMilliseconds;
    private int _waveIndex;
    private bool _waveCleared;

    private void Start()
    {
        _totalTimeInMilliseconds = TotalGameTimeInMinutes * 1000 * 60;
        _currentTimeInMilliseconds = 0;
        WatcherComponent.EnemiesCleared += OnEnemiesCleared;
        HandleWaves().Forget();
    }

    private void OnDestroy()
    {
        WatcherComponent.EnemiesCleared -= OnEnemiesCleared;
    }

    private void OnEnemiesCleared()
    {
        _waveCleared = true;
    }

    private async UniTask HandleWaves()
    {
        while (_totalTimeInMilliseconds > _currentTimeInMilliseconds)
        {
            if (_waveIndex > WaveConfigs.Count-1)
            {
                _waveIndex = WaveConfigs.Count - 1;
            }
            WaveDelayStarted?.Invoke(_waveIndex, WaveConfigs[_waveIndex].DelayInSeconds * 1000);
            await UniTask.Delay(WaveConfigs[_waveIndex].DelayInSeconds * 1000);
            _currentTimeInMilliseconds += WaveConfigs[_waveIndex].DelayInSeconds * 1000;
            var waveStatus = SpawnWave(WaveConfigs[_waveIndex]);
            _waveCleared = false;
            WaveSpawn?.Invoke(waveStatus);
            _waveIndex++;
            await UniTask.WaitUntil(() => _waveCleared);
        }
    }

    private WaveStatus SpawnWave(WaveConfig config)
    {
        List<int> directions = new ();
        for (int i = 0; i < config.NumberOfDirections; i++)
        {
            directions.Add(Random.Range(0,4));
        }

        List<HealthComponent> healthComponents = new ();
        Dictionary<CircularSpawner.Direction, bool> directionsDict = new();
        for (int i = 0; i < config.QuantityOfEnemies; i++)
        {
            var dir = (CircularSpawner.Direction) RandomUtils.GetRandomElementFromList(directions);
            directionsDict.TryAdd(dir, true);
            var enemy = Spawner.Spawn(config.GetEnemyPrefab(),dir);
            healthComponents.Add(enemy.GetComponent<HealthComponent>());
        }

        return new WaveStatus(directionsDict.Keys.ToList(), healthComponents);
    }
}