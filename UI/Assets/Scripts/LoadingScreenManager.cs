using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenManager : MonoBehaviour
{
    public Image progressBar;
    public static LoadingScreenManager loadaing;
    public int level = 1;
    private void Awake()
    {

        loadaing = this;
        level = PlayerPrefs.GetInt("Level", level);

    }

    private void Start()
    {
        StartCoroutine(LoadAsync(level));
    }
    public void LoadLevelWithImage()
    {
        StartCoroutine(LoadAsync(level));
    }

    IEnumerator LoadAsync(int level)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(level);

        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);

            progressBar.fillAmount = progress;

            yield return null;
        }
    }

    public void NextLevel()
    {
        level += 1;
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.Save();
    }
}
