using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class RandomUtils
    {
        public static T GetRandomElementFromList<T>(IReadOnlyList<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }
    }
}