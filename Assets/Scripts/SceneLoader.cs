using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScene;
    public Slider loadingBar;
    public TextMeshProUGUI progressText;
    

    public void LoadScene(int levelIndex)
    {   
        UpdateProgressUI(0);

        StartCoroutine(LoadSceneAsynchronously(levelIndex));
    }

    IEnumerator LoadSceneAsynchronously(int levelIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        loadingScene.SetActive(true);
        while(!operation.isDone)
        {
            UpdateProgressUI(operation.progress);
            yield return null;
        }

        UpdateProgressUI(operation.progress);
		operation = null;
    }

	private void UpdateProgressUI(float progress)
	{
		loadingBar.value = progress;
		progressText.text = (int)(progress * 100f) + "%";
	}
}
