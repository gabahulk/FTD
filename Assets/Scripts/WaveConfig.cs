using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/WaveConfig", fileName = "WaveConfig")]
public class WaveConfig:ScriptableObject
{
    public List<GameObject> EnemiesPrefabs = new List<GameObject>();
    public List<int> SpawnWeights = new List<int>();
    public int QuantityOfEnemies;
    public int DelayInSeconds;
    [Range(1,4)]
    public int NumberOfDirections;

    private List<GameObject> _enemiesPrefabSampler;

    private void OnValidate()
    {
        while (EnemiesPrefabs.Count > SpawnWeights.Count)
        {
            SpawnWeights.Add(1);
        }
        
        while (EnemiesPrefabs.Count < SpawnWeights.Count)
        {
            SpawnWeights.RemoveAt(SpawnWeights.Count-1);
        }

        _enemiesPrefabSampler = new List<GameObject>();

        for (int i = 0; i < SpawnWeights.Count; i++)
        {
            for (int j = 0; j < SpawnWeights[i]; j++)
            {
                _enemiesPrefabSampler.Add(EnemiesPrefabs[i]);
            }
        }
    }

    public GameObject GetEnemyPrefab()
    {
        int index = Random.Range(0, _enemiesPrefabSampler.Count);
        return _enemiesPrefabSampler[index];
    }
}