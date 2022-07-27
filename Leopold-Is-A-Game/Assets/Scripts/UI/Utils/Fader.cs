using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public Image fader;

    public bool IsOpaque => fader.color.a >= 1f;
    public bool IsClear => fader.color.a <= 0f;


    public static Color Opaque = new Color(1f, 1f, 1f, 1f);
    public static Color Clear  = new Color(1f, 1f, 1f, 0f);

    public SituationHandler dialoger;
    public StoryHandler handler;

    private void Awake()
    {
        fader = GetComponent<Image>();
    }

    // Clear to Opaque
    public void FadeIn(float ratio = 1f) => fader.color = new Color(0f, 0f, 0f, fader.color.a + (ratio* Time.deltaTime));

    // Opaque to Clear
    public void UnFade(float ratio = 1f) => fader.color = new Color(0f, 0f, 0f, fader.color.a - (ratio * Time.deltaTime));

    public void SetOpaque() => fader.color = new Color(0f, 0f, 0f, 1f);
    public void SetClear() => fader.color = new Color(0f, 0f, 0f, 0f);

    public void UnFadeWakeUp() 
    {
        StartCoroutine(WakeUp());
    }

    public void StartDialog() 
    {
        dialoger.SendNextDialog();
    }

    public void BlockTexts() => handler.isFading = true;
    IEnumerator WakeUp() 
    {
        while (!IsClear)
        {
            UnFade(.5f);
            yield return null;
        }

        handler.isFading = false;
    }

}
