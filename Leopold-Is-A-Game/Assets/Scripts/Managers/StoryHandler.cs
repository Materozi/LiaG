using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Debug.Log(story.ToString());
        SendNextSituation();
    }

    public void SendNextSituation() 
    {
        situationIndex++;
        //end the tome depending on which one was it
        if (situationIndex >= story.situations.Count) 
        {
            PlayerPrefs.SetString("backTome", story.ToString());
            //Goto MainMenu
            //Fuck this shit i'm out
            SceneManager.LoadScene("MainMenu");
        }

        if (situationIndex >= 0 && story.situations[situationIndex].hasVisualEffect && SituationHandler.dialogIndex == -1)
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
