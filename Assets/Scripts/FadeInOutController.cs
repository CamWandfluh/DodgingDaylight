using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOutController : MonoBehaviour {

    public CanvasGroup uiElement;

    IEnumerator Start()
    {
        yield return StartCoroutine(WaitAndPrint(3.0F));
    }
    IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0));
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 0.5f)
    {
        float timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while(true)
        {
            timeSinceStarted = Time.time - timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }

        print("Done");
    }
}
