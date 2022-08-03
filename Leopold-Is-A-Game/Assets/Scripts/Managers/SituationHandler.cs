using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(SituationDisplayer))]
public class SituationHandler : MonoBehaviour
{
    public Situation situation;

    public StoryHandler storyHandler;
    SituationDisplayer display;

    public static int dialogIndex = -1;

    private void Start()
    {
        display = GetComponent<SituationDisplayer>();
    }

    public void SetSituation(Situation _situation) 
    {
        situation = _situation;
        // play different sound if needed
        SoundManager.ChangeAmbiantSound(situation.ambiantMusic);
        display.DisplaySituation(situation);
        if (!situation.hasVisualEffect || dialogIndex != -1)
            SendNextDialog();
    }

    private void Update()
    {
        if (StoryHandler.isFading || PauseMenu.isGamePaused)
            return;
        
        if (Input.GetMouseButtonDown(0) && CheckIfCanClick())
        {
            if (display.IsWriting)
                display.textWriting.DisplayFullText();
            else
                SendNextDialog();
        }
    }

    public void SendNextDialog() 
    {
        dialogIndex++;

        if (dialogIndex >= situation.dialogs.Count)
        {
            dialogIndex = -1;
            storyHandler.SendNextSituation();
        }
        else 
            display.DisplayDialog(situation.dialogs[dialogIndex]);
    }

    public void SendPreviousDialog()
    {
        if (dialogIndex <= 0)
            return;
        
        dialogIndex--;
        display.DisplayDialog(situation.dialogs[dialogIndex]);
    }

    //return true if there is no buttons below the mouse
    bool CheckIfCanClick() 
    {
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycastResults);

        foreach (RaycastResult res in raycastResults) 
            if (res.gameObject.TryGetComponent<Button>(out Button b))
                return false;

        if (Time.timeScale == 0f)
            return false;

        return true;
    }
}
