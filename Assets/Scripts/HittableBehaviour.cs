using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableBehaviour : MonoBehaviour
{
    public Action Hit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag($"Weapon")) return;
        Debug.Log("I'm hit!");
        Hit?.Invoke();
    }
}
