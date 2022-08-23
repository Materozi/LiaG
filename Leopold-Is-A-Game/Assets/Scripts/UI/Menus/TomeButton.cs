using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TomeButton : MonoBehaviour
{

    public string key = "";
    public string tomeName = "";
    public string extension = "";
    public void OnEnable()
    {
        bool value = PlayerPrefs.HasKey(key);
        GetComponent<Button>().interactable = value;
        extension = value ? "unlocked" : "locked";
        GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/"+tomeName+"_"+extension);
    }
}
