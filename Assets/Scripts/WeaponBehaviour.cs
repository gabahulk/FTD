using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponBehaviour : MonoBehaviour
{
    public GameObject HitBox;
    public int HitTimeInMilliseconds;
    public int HitCooldownInMilliseconds;

    private bool _isAnimating = false;

    private void Awake()
    {
        HitBox.SetActive(false);
    }

    public async void Attack(InputAction.CallbackContext value)
    {
        if (_isAnimating) return;
        
        HitBox.SetActive(true);
        _isAnimating = true;
        await UniTask.Delay(HitTimeInMilliseconds);
        HitBox.SetActive(false);
        await UniTask.Delay(HitCooldownInMilliseconds);
        _isAnimating = false;
    }
    
}
