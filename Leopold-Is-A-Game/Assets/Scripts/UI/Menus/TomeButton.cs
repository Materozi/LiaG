using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TomeButton : MonoBehaviour
{

    public string key = "";
    public void OnEnable()
    {
        GetComponent<Button>().interactable = PlayerPrefs.HasKey(key);
    }
}
