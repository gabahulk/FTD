using System.Collections;
using System.Collections.Generic;
using Configs.Scripts;
using UnityEngine;

public class ChaseCharacterBehaviour : MonoBehaviour
{
    public Transform Target;
    public float Speed;
    public GameDebugConfig GameDebugConfig;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move((Target.position - transform.position).normalized);
    }

    private void Move(Vector2 movement)
    {
        transform.Translate(movement * Speed * Time.deltaTime, Target);
        if (GameDebugConfig.DebugChaseBehaviour)
        {
            Debug.DrawRay(transform.position, movement * Speed, Color.magenta);
        }
    }
}
