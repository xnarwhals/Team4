using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*public class LoadingManager : MonoBehaviour
{

    public static LoadingManager Instance;

    public GameObject LoadingPanel; // Public Slider? Somewhere in the code insert "LoadingPanel.value = asyncLoad.progress"
    public float MinLoadTime;

    public GameObject LoadingWheel;
    public float WheelSpeed;

    public Image FadeImage;
    public float FadeTime;

    private bool isLoading;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        LoadingPanel.SetActive(false);
        FadeImage.gameObject.SetActive(false);
    }

    private IEnumerator LoadSceneRoutine()
    {

        isLoading = true;

        FadeImage.gameObject.SetActive(true);
        FadeImage.canvasRenderer.SetAlpha(0);

        while (!Fade(1))
            yield return null;

        LoadingPanel.SetActive(true);
        StartCoroutine(SpinWheelRoutine());

        while (!Fade(0))
            yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync(targetScene);
        float elapsedLoadTime = 0f;

        while (!op.isDone)
        {
            elapsedLoadTime += Time.deltaTime;
            yield return null; // It continues running until it goes into the yield
        }

        while (elapsedLoadTime < MinLoadTime)
        {
            elapsedLoadTime += Time.deltaTime;
            yield return null;
        }

        while (!Fade(1))
            yield return null;

        LoadingPanel.SetActive(false);

        while (!Fade(0))
            yield return null;

        isLoading = false;
    }

    private bool Fade(float target)
    {
        FadeImage.CrossFadeAlpha(target, FadeTime, true);

        if (Mathf.Abs(FadeImage.canvasRenderer.GetAlpha() - target) <= 0.05f)
        {
            FadeImage.canvasRenderer.SetAlpha(target);
            return true;
        }

        return false;
    }

    private IEnumerator SpinWheelRoutine()
    {
        while (isLoading)
        {
            LoadingWheel.transform.Rotate(0, 0, -WheelSpeed);
            yield return null;
        }
    }
}*/