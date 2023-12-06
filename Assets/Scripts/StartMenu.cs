using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{   
    // public StartPosition startPosition;
    public void StartGame()
    {
        SceneManager.LoadScene("LobbyScene");
        // transform.position = startPosition.initialValue;
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
