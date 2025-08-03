using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenuManagement : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Image fadeImage;
    [SerializeField] private string sceneToLoad = "CityScene";
    [SerializeField] private float fadeDuration = 1f;

    public void OnPlayClicked()
    {
        StartCoroutine(LoadSceneWithFade());
    }

    private IEnumerator LoadSceneWithFade()
    {
        loadingScreen.SetActive(true);

        // Fade to black
        float t = 0f;
        Color color = fadeImage.color;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Clamp01(t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        // Async scene loading
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!op.isDone)
        {
            // Optional: Show progress bar
            yield return null;
        }
    }
}
