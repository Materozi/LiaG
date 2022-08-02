using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoaderDisplay : MonoBehaviour
{
    public int value = 0;

    public TMPro.TextMeshProUGUI text;
    public Image img;

    public void Refresh(int v) 
    {
        value = v;
        text.text = "Sauvegarde " + (v + 1);
        // Screenshot
        img.sprite = DataSaver.LoadSprite(Application.persistentDataPath + '/' + v+".png");
    }

    public void ClickLoad() 
    {
        DataSaver.Load(value);
        SceneManager.LoadScene("Game");
    }
}
