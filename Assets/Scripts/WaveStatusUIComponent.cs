using System;
using UnityEngine;

public class WaveStatusUIComponent : MonoBehaviour
{
   public EnemiesLeftUIComponent EnemiesRemaining;
   public WaveTimerUIComponent WaveTimer;
   
   public WaveSpawnerComponent WaveSpawnerComponent;

   private void Awake()
   {
      WaveSpawnerComponent.WaveSpawn += OnWaveSpawn;
      WaveSpawnerComponent.WaveDelayStarted += OnWaveDelayStarted;
   }
   
   private void OnDestroy()
   {
      WaveSpawnerComponent.WaveSpawn -= OnWaveSpawn;
      WaveSpawnerComponent.WaveDelayStarted -= OnWaveDelayStarted;
   }

   private void OnWaveDelayStarted(int waveIndex,int waveDelay)
   {
      EnemiesRemaining.ToggleLabel(false);
      WaveTimer.ToggleLabel(true);
   }

   private void OnWaveSpawn(WaveStatus obj)
   {
      EnemiesRemaining.ToggleLabel(true);
      WaveTimer.ToggleLabel(false);
   }
}
