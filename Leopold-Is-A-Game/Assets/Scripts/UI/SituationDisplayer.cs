using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SituationDisplayer : MonoBehaviour
{
    public Image background = null;

    public Image leftChibi  = null;
    public Image rightChibi = null;

    public TMPro.TextMeshProUGUI text      = null;
    public TMPro.TextMeshProUGUI charaName = null;

    public TextWrittingEffect textWriting = null;

    public Animator visualEffecter = null;

    public bool IsWriting => textWriting.isWriting;

    public void DisplaySituation(Situation situation) 
    {
        background.sprite = situation.backgroud;
    }

    public void DisplayText(Dialog dialog)
    {
        leftChibi.color = Fader.Clear;
        rightChibi.color = Fader.Clear;

        if (dialog.charaSide == CharaSide.LEFT)
        {
            leftChibi.color = Fader.Opaque;
            leftChibi.sprite = Characters.GetCharacterSprite(dialog.chara);
        }
        else if (dialog.charaSide == CharaSide.RIGHT)
        {
            rightChibi.color = Fader.Opaque;
            rightChibi.sprite = Characters.GetCharacterSprite(dialog.chara);
        }

        charaName.text = Characters.GetCharacterName(dialog.chara);
        textWriting.InitializeWriting(dialog.text);

        if (dialog.audioEffect)
            SoundManager.PlayDialogSound(dialog.audioEffect);
    }
    public void DisplayDialog(Dialog dialog)
    {
        if (dialog.hasVisualEffect)
        {
            visualEffecter.SetTrigger(dialog.ToString());
        }
        else 
        {
            DisplayText(dialog);
        }    
    }
}
