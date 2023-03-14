using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerControllableComponent PlayerControllableComponent;
    
    private Vector3 _input;
    private bool _isMoving;
    
    public void OnMovement(InputAction.CallbackContext value)
    {
        var rawInput = value.ReadValue<Vector2>();
        _input = new Vector3(rawInput.x, rawInput.y, 0);
        _isMoving = (value.started || value.performed) && !value.canceled;
        if (value.started)
        {
            StartCoroutine(nameof(MoveCoroutine));
        }
    }
    
    private IEnumerator MoveCoroutine()
    {
        while (_isMoving)
        {
            PlayerControllableComponent.Move(_input);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
