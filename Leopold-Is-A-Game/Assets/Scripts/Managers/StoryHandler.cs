using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryHandler : MonoBehaviour
{
    public static Story story;

    public SituationHandler situationHandler;

    public static int situationIndex = -1;
     
    public static bool isFading = false;

    public Fader fader;
    public Animator animator;

    private void Start()
    {
        SendNextSituation();
    }

    public void SendNextSituation() 
    {
        situationIndex++;
        if (story.situations[situationIndex].hasVisualEffect && SituationHandler.dialogIndex == -1)
        {
            animator.SetTrigger(story.situations[situationIndex].ToString());
            situationHandler.SetSituation(story.situations[situationIndex]);
        }
        else if (story.situations[situationIndex].ignoreTransition) 
        {
            situationHandler.SetSituation(story.situations[situationIndex]);
        }
        else
        {
            StartCoroutine(FadeScreen());
        }
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
