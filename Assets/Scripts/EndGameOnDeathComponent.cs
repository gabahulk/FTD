using UnityEngine;

public class EndGameOnDeathComponent : MonoBehaviour
{
    public HealthComponent HealthComponent;
    private GameManager _gameManager;
    private void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        HealthComponent.Death += OnDeath;
    }

    private void OnDestroy()
    {
        HealthComponent.Death -= OnDeath;
    }
    
    
    private void OnDeath()
    {
        _gameManager.EndGame();
    }
}
