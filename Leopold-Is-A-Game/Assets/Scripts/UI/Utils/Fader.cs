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

    public AudioClip radio;
    public AudioClip gifle;
    public AudioClip gunshot;
    private void Awake()
    {
        fader = GetComponent<Image>();
    }

    // Clear to Opaque
    public void FadeIn(float ratio = 1f) => fader.color = new Color(0f, 0f, 0f, fader.color.a + (ratio* Time.deltaTime));

    // Opaque to Clear
    public void UnFade(float ratio = 1f) => fader.color = new Color(0f, 0f, 0f, fader.color.a - (ratio * Time.deltaTime));

    // Clear to Opaque
    public void FadeInEx(float ratio = 1f) => fader.color = new Color(1f, 1f, 1f, fader.color.a + (ratio * Time.deltaTime));

    // Opaque to Clear
    public void UnFadeEx(float ratio = 1f) => fader.color = new Color(1f, 1f, 1f, fader.color.a - (ratio * Time.deltaTime));

    public void SetOpaque() => fader.color = new Color(0f, 0f, 0f, 1f);
    public void SetClear() => fader.color = new Color(0f, 0f, 0f, 0f);

    public void UnFadeWakeUp() 
    {
        if (SituationHandler.dialogIndex == 0 || StoryHandler.situationIndex != 0)
            return;

        StartCoroutine(WakeUp());
    }

    public void StartDialog() 
    {
        if (SituationHandler.dialogIndex == 0 || StoryHandler.situationIndex != 0)
            return;

        dialoger.SendNextDialog();
    }

    public void BlockTexts()
    {
        if (SituationHandler.dialogIndex >= 0 || StoryHandler.situationIndex != 0)
            return;

        StoryHandler.isFading = true;
        GetComponent<AudioSource>().clip = radio;
        GetComponent<AudioSource>().Play();
    }
    IEnumerator WakeUp() 
    {
        while (!IsClear)
        {
            UnFade(.5f);
            yield return null;
        }

        StoryHandler.isFading = false;
    }

    public void Flash() 
    {
        StartCoroutine(FlashC());
    }

    IEnumerator FlashC()
    {
        GetComponent<AudioSource>().clip = gifle;
        GetComponent<AudioSource>().Play();

        while (!IsOpaque) 
        {
            FadeInEx(9f);
            yield return null;
        }

        yield return new WaitForSeconds(.05f);
        dialoger.SendNextDialog();

        while (!IsClear)
        {
            UnFadeEx(6f);
            yield return null;
        }

        StoryHandler.isFading = false;
    }
}
