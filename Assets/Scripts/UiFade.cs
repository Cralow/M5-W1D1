using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UiFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup uiGroup;
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private UnityEvent startFade;

    private Coroutine currentFadeCoroutine;

    public void ShowUI()
    {
        StartFade(1f); 
    }

    public void HideUI()
    {
        StartFade(0f); //stoppa a zero
    }

    private void StartFade(float targetAlpha)
    {

        if (currentFadeCoroutine != null)
        {
            StopCoroutine(currentFadeCoroutine);
            print("Stoppata una coroutine");
        }

        currentFadeCoroutine = StartCoroutine(FadeUI(targetAlpha));
    }

    private IEnumerator FadeUI(float time)
    {
        float startAlpha = uiGroup.alpha;
        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            uiGroup.alpha = Mathf.Lerp(startAlpha, time, timeElapsed / fadeDuration);
            yield return null;
        }

        uiGroup.alpha = time;
        currentFadeCoroutine = null;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (uiGroup.alpha == 0f)
            {
                ShowUI();
            }
            else if (uiGroup.alpha == 1f)
            {
                HideUI();
            }
            

        }
    }
}
