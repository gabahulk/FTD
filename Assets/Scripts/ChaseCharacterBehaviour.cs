using Configs.Scripts;
using UnityEngine;

public class ChaseCharacterBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform CurrentTarget;
    private Transform _player;
    private Transform _throne;
    private Transform _transform;
    
    public float Speed;
    public GameDebugConfig GameDebugConfig;
    void Start()
    {
        _transform = transform;
        _player = GameObject.FindWithTag("Player").transform;
        _throne = GameObject.FindWithTag("Throne").transform;
        CurrentTarget = _throne;
    }

    private void Update()
    {
        if (_transform == null || _player==null || _throne==null)
        {
            return;
        }
        CurrentTarget = GetCurrentTarget();
        Move((CurrentTarget.position - transform.position).normalized);
    }

    private Transform GetCurrentTarget()
    {
        var position = _transform.position;
        float distanceFromPlayer = Vector2.Distance(position, _player.position);
        float distanceFromThrone = Vector2.Distance(position, _throne.position);
        return distanceFromPlayer < distanceFromThrone ? _player : _throne;
    }

    private void Move(Vector2 movement)
    {
        transform.Translate(movement * Speed * Time.deltaTime, CurrentTarget);
        if (GameDebugConfig.DebugChaseBehaviour)
        {
            Debug.DrawRay(transform.position, movement * Speed, Color.magenta);
        }
    }
}
