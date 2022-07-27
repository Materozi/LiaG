using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAnimations : MonoBehaviour
{
    public StoryHandler handler    = null;
    public SituationDisplayer disp = null;
    public Animator anim;
    public void StartBlockText()
    {
        handler.isFading = true;
        disp.DisplayText(handler.situationHandler.situation.dialogs[handler.situationHandler.dialogIndex]);
    }
    public void EndBlockTexts() 
    {
        handler.isFading = false;
        handler.situationHandler.SendNextDialog();
        anim.SetTrigger("leave");
    }
}
