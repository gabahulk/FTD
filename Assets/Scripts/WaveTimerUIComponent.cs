using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

public class WaveTimerUIComponent : MonoBehaviour
{
   public TMP_Text WaveTimerLabel;
   public WaveSpawnerComponent WaveSpawnerComponent;

   private void Awake()
   {
      WaveSpawnerComponent.WaveDelayStarted += OnWaveDelayStarted;
   }

   public void ToggleLabel(bool status)
   {
      WaveTimerLabel.enabled = status;
   }
   
   private void OnDestroy()
   {
      WaveSpawnerComponent.WaveDelayStarted -= OnWaveDelayStarted;
   }

   private void OnWaveDelayStarted(int wave, int timeInMilliseconds)
   {
      Countdown(timeInMilliseconds).Forget();
   }

   private async UniTask Countdown(int timeInMilliseconds)
   {
      do
      {
         WaveTimerLabel.text = $"Time to Next Wave: {TimeSpan.FromMilliseconds(timeInMilliseconds).ToString(@"hh\:mm\:ss")}";
         await UniTask.Delay(1000);
         timeInMilliseconds -= 1000;
      } while (timeInMilliseconds > 0);
   }
}
