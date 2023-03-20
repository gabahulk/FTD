using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SceneController SceneController;
    public bool IsGamePlaying;

    private void Awake()
    {
        IsGamePlaying = true;
    }

    public void EndGame()
    {
        IsGamePlaying = false;
        SceneController.LoadGameOver();
    }

}
