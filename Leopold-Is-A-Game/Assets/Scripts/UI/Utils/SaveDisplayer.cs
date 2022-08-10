using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDisplayer : MonoBehaviour
{
    public GameObject savePrefab;

    private void OnEnable()
    {
        foreach (Transform t in transform)
            Destroy(t.gameObject);
        
        ParseSaves();    
    }

    public void ParseSaves() 
    {
        // try to read the 7 saves
        for (int i = 0; i < 7; i++) 
        {
            // if the save is used, instantiate prefab
            if (PlayerPrefs.HasKey("Save" + i)) 
            {
                Transform t = Instantiate(savePrefab).transform;
                t.SetParent(transform);
                t.GetComponent<LoaderDisplay>().Refresh(i);
            }
        }
    }
}
