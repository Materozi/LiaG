using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Situation", menuName = "ScriptableObjects/Situation", order = 2)]
public class Situation : ScriptableObject
{
    // background
    public Sprite backgroud = null;
    // left  group dialogs
    public List<Dialog> dialogs = new List<Dialog>();
    // Visual effect if needed
    public Animation visualEffect = null;
}
