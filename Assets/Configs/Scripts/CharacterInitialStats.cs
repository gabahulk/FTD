using UnityEngine;

namespace Configs.Scripts
{
    [CreateAssetMenu(menuName = "Game/CharacterStats", fileName = "CharacterStats")]
    public class CharacterInitialStats : ScriptableObject
    {
        public float Speed;
        public float Health;
    }
}
