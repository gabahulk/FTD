using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllableComponent : MonoBehaviour
{
    [SerializeField] private PlayerStatsController PlayerStatsController;

    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    public void Move(Vector2 movement)
    {
        _transform.Translate(movement * PlayerStatsController.Speed* Time.deltaTime);
    }
}
