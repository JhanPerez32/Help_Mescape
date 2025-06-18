using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider LoadingBarFill;

    public void LoadScene(string sceneID)
    {
        StartCoroutine(LoadSceneAsync(sceneID));
    }

    IEnumerator LoadSceneAsync(string sceneID)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            LoadingBarFill.value = progressValue;

            yield return null;
        }
    }
}
