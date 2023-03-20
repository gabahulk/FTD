using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public async void LoadGame()
    {
        await SceneManager.LoadSceneAsync("Game");
    }
    
    public async void LoadMainMenu()
    {
        await SceneManager.LoadSceneAsync("MainMenu");
    }
    
    public async void LoadGameOver()
    {
        await SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Additive);
    }
}
