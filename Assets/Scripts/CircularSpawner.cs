using System;
using System.Collections;
using System.Collections.Generic;
using Configs.Scripts;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CircularSpawner : MonoBehaviour
{
    public enum Direction
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3
    }

    public Transform ReferenceTransform;
    public Transform ParentTransform;

    public float InnerRadius;
    public float OuterRadius;

    public GameDebugConfig GameDebugConfig;


    private readonly Dictionary<Direction, Func<float>> _directionRandomAngle = new()
    {
        {Direction.North, GetNorthAngle},
        {Direction.East, GetEastAngle},
        {Direction.South, GetSouthAngle},
        {Direction.West, GetWestAngle},
    };
    private void Update()
    {
        if (!GameDebugConfig.DebugCircularSpawner) return;
        var position = ReferenceTransform.position;
        DrawDebugCircle(position, InnerRadius);
        DrawDebugCircle(position, OuterRadius);
    }

    private void DrawDebugCircle(Vector3 position, float radius)
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

    private static float GetNorthAngle()
    {
        return Random.Range(270f, 450f) * Mathf.Deg2Rad;
    }
    
    private static float GetSouthAngle()
    {
        return Random.Range(90f, 270f) * Mathf.Deg2Rad;
    }
    
    private static float GetEastAngle()
    {
        return Random.Range(0f, 180f) * Mathf.Deg2Rad;
    }
    
    private static float GetWestAngle()
    {
        return Random.Range(180f, 360f) * Mathf.Deg2Rad;
    }

    public GameObject Spawn(GameObject prefab, Direction direction)
    {
        //choose a random angle based on direction
        float angle = _directionRandomAngle[direction].Invoke();
        float radius = Random.Range(InnerRadius, OuterRadius);
        var point = new Vector2(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle));
        var position = ReferenceTransform.position;
        point += (Vector2) position;

        var obj = Instantiate(prefab, point, Quaternion.identity);
        obj.transform.up = (position - obj.transform.position).normalized;
        obj.transform.parent = ParentTransform;
        return obj;
    }
}
