using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryHandler : MonoBehaviour
{
    public Story story;

    public SituationHandler situationHandler;

    int situationIndex = -1;

    public bool isFading = false;

    public Fader fader;

    private void Start()
    {
        SendNextSituation();
    }

    public void SendNextSituation() 
    {
        situationIndex++;
        StartCoroutine(FadeScreen());
    }

    IEnumerator FadeScreen()
    {
        isFading = true;
        while (!fader.IsOpaque) 
        {
            fader.FadeIn();
            yield return null;
        }

        yield return new WaitForSeconds(.5f);

        situationHandler.SetSituation(story.situations[situationIndex]);

        while (!fader.IsClear) 
        {
            fader.UnFade();
            yield return null;
        }
        isFading = false;
    }


}
