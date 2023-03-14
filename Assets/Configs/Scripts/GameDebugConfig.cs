using UnityEngine;

namespace Configs.Scripts
{
   [CreateAssetMenu(menuName = "Game/GameDebugConfig", fileName = "GameDebugConfig")]
   public class GameDebugConfig : ScriptableObject
   {
      public bool DebugAimingBehaviour;
   }
}
