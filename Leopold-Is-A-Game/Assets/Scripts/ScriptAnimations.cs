using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAnimations : MonoBehaviour
{
    public StoryHandler handler    = null;
    public SituationDisplayer disp = null;
    public Animator anim;
    public Fader fader = null;

    public void StartBlockText()
    {
        StoryHandler.isFading = true;
        disp.DisplayText(handler.situationHandler.situation.dialogs[SituationHandler.dialogIndex]);
    }
    public void EndBlockTexts() 
    {
        StoryHandler.isFading = false;
        handler.situationHandler.SendNextDialog();
        anim.SetTrigger("leave");
    }

    public void Shotgun() 
    {
        fader.Gunshot();
    }
}
