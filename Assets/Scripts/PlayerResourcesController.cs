using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResourcesController : MonoBehaviour
{
    private readonly Dictionary<GameResourceType, int> _wallet = new Dictionary<GameResourceType, int>();
    public Action<GameResourceType, int> UpdateWallet;

    
    public void AddResource(GameResourceType type, int quantity)
    {
        if (!_wallet.ContainsKey(type))
        {
            _wallet.Add(type, 0);
        }

        _wallet[type] += quantity;
        UpdateWallet?.Invoke(type,_wallet[type]);
    }
}
