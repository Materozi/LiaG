using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG : MonoBehaviour
{
    public StoryHandler handler;
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            SituationHandler.dialogIndex = -1;
            handler.SendNextSituation();
        }
    }
}
