using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Story", menuName = "ScriptableObjects/Story", order = 3)]
public class Story : ScriptableObject
{
    public List<Situation> situations = new List<Situation>();
}
