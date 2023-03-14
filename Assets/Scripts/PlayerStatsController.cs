using System.Collections;
using System.Collections.Generic;
using Configs.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerStatsController : MonoBehaviour
{
    [SerializeField] private CharacterInitialStats InitialStats;
    public float Speed => InitialStats.Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
