using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

public class ResourceSpawner : MonoBehaviour
{
    public List<GameObject> ResourcePrefabs;
    public int SpawnDelayInMilliseconds;
    public Transform Target;
    public Transform Parent;
    public SpriteRenderer TargetSprite;
    public Action<Transform> ResourceSpawned;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        for (int i = 0; i < 100; i++)
        {
            InstantiateResource();
        }
        HandleSpawning().Forget();
    }

    private async UniTask HandleSpawning()
    {
        while (_gameManager.IsGamePlaying)
        {
            await UniTask.Delay(SpawnDelayInMilliseconds);
            var resource = InstantiateResource();
            ResourceSpawned?.Invoke(resource.transform);
        }
    }

    private GameObject InstantiateResource()
    {
        var bounds = TargetSprite.bounds;
        Vector3 pos;
        do
        {
            float xPos = Random.Range(-bounds.size.x / 2, bounds.size.x / 2);
            float yPos = Random.Range(-bounds.size.y / 2, bounds.size.y / 2);
            pos = new Vector3(xPos, yPos, 0) - Target.transform.position;
        } while (Physics2D.CircleCast((Vector2)pos, 3, Vector2.down).collider != null);
       
        
        var resource = Instantiate(RandomUtils.GetRandomElementFromList(ResourcePrefabs), pos, Quaternion.identity);
        resource.transform.parent = Parent;
        return resource;
    }
}
