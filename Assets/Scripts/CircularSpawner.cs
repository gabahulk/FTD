using System;
using System.Collections;
using System.Collections.Generic;
using Configs.Scripts;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CircularSpawner : MonoBehaviour
{
    public Transform ReferenceTransform;
    public Transform ParentTransform;

    public float InnerRadius;
    public float OuterRadius;

    public GameDebugConfig GameDebugConfig;

    public GameObject Enemy;

    private void Update()
    {
        if (!GameDebugConfig.DebugCircularSpawner) return;
        var position = ReferenceTransform.position;
        DrawDebugCircle(position, InnerRadius);
        DrawDebugCircle(position, OuterRadius);
    }

    private void Awake()
    {
       
    }

    public void DrawDebugCircle(Vector3 position, float radius)
    {
        const int numberOfPoints = 360;
        var lastPoint = new Vector2(radius * Mathf.Cos(0) + position.x, radius * Mathf.Sin(0) + position.y);
        for (int i = 1; i < numberOfPoints; i++)
        {
            float angle = i * Mathf.Deg2Rad;
            var point = new Vector2(radius * Mathf.Cos(angle) + position.x, radius * Mathf.Sin(angle) + position.y);
            Debug.DrawLine(lastPoint, point, Color.magenta);
            lastPoint = point;
        }
    }

    public void Spawn(GameObject prefab)
    {
        //choose a random angle
        float angle = Random.Range(1f, 360f) * Mathf.Deg2Rad;
        float radius = Random.Range(InnerRadius, OuterRadius);
        var point = new Vector2(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle));
        var position = ReferenceTransform.position;
        point += (Vector2) position;

        var obj = Instantiate(prefab, point, Quaternion.identity);
        obj.transform.up = (position - obj.transform.position).normalized;
        obj.transform.parent = ParentTransform;
    }
}
