using Configs.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class AimingBehaviour : MonoBehaviour
{
    [SerializeField] private Transform AimTransform;
    [SerializeField] private GameDebugConfig Config;
    [SerializeField] private Camera Camera;

    //set it up with unity input system
    public void Aim(InputAction.CallbackContext value)
    {
        var rawInput = value.ReadValue<Vector2>();
        var mousePos = Camera.ScreenToWorldPoint(rawInput);
        mousePos = new Vector3(mousePos.x, mousePos.y, 0);
        AimTransform.up = (mousePos - AimTransform.position).normalized;

        if (Config != null && Config.DebugAimingBehaviour)
        {
            Debug.DrawRay(AimTransform.position, mousePos, Color.magenta);
        }
    }
}