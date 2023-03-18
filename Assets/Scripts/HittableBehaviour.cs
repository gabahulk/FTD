using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HittableBehaviour : MonoBehaviour
{
    public Action Hit;
    public List<string> CollisionTags;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!ShouldCollide(other)) return;
        Debug.Log($"I'm hit! Hitter is: {other.gameObject.name}");
        Hit?.Invoke();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!ShouldCollide(other)) return;
        Debug.Log($"I'm hit! Hitter is: {other.gameObject.name}");
        Hit?.Invoke();
    }

    private bool ShouldCollide(Collider2D other)
    {
        return CollisionTags.Any(other.gameObject.CompareTag);
    }
    
    private bool ShouldCollide(Collision2D other)
    {
        return CollisionTags.Any(other.gameObject.CompareTag);
    }
}
