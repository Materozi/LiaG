using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SituationDisplayer))]
public class SituationHandler : MonoBehaviour
{
    public Situation situation;

    public StoryHandler storyHandler;
    SituationDisplayer display;

    List<Character> leftCharacters = new List<Character>();
    List<Character> rightCharacters = new List<Character>();

    int dialogIndex = -1;


    private void Start()
    {
        display = GetComponent<SituationDisplayer>();
        PopulateChibis();
    }

    public void SetSituation(Situation _situation) 
    {
        situation = _situation;
        PopulateChibis();
        display.DisplaySituation(situation);
        SendNextDialog();
    }

    void PopulateChibis()
    {
        foreach (Dialog dialog in situation.dialogs)
        {
            if (dialog.charaSide == CharaSide.LEFT && !leftCharacters.Contains(dialog.chara))
            {
                leftCharacters.Add(dialog.chara);
                continue;
            }

            if (dialog.charaSide == CharaSide.RIGHT && !rightCharacters.Contains(dialog.chara))
            {
                rightCharacters.Add(dialog.chara);
                continue;
            }
        }
    }

    private void Update()
    {
        if (storyHandler.isFading)
            return;
        
        if (Input.GetMouseButtonDown(0))
        {
            if (display.IsWriting)
                display.textWriting.DisplayFullText();
            else
                SendNextDialog();
        }
    }

    void SendNextDialog() 
    {
        dialogIndex++;

        if (dialogIndex >= situation.dialogs.Count)
        {
            storyHandler.SendNextSituation();
            dialogIndex = -1;
        }
        else 
        {
            display.DisplayDialog(situation.dialogs[dialogIndex]);
        }
    }
}
