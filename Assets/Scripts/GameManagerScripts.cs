using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManagerScripts : MonoBehaviour
{
    

    public GameObject overSceneUI;
    public GameObject pauseSceneUI;
    public GameObject respawnPoint;
    

    public static GameManagerScripts instance;

    public Transform player;

    private void Awake()
    {
    
        if (instance == null)
        {
            instance = this;
        }
        
        allDialogueTriggers  = FindObjectsOfType<DialougeTrigger>();

    }

    public DialougeTrigger[] allDialogueTriggers;

    public delegate void OnEnemyDeathCallBack(EnemyProfile enemyProfile);
    public OnEnemyDeathCallBack onEnemyDeathCallBack;

    public RewardManager rewardManager;

    public TextMeshProUGUI trackerText;
    public Animator trackerAmin;

    public void UpdateTracker(string newText)
    {
        trackerText.text = newText;
        trackerAmin.Play("TrackerText");
    }

    public void GameOver()
    {
        overSceneUI.SetActive(true);
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("LobbyScene");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseSceneUI.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseSceneUI.SetActive(false);
    }

    
}

    
