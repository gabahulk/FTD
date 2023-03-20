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
}
