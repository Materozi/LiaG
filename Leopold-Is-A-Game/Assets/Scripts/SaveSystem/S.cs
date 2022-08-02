using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class S : MonoBehaviour
{
    public Image image;
    public int save;
    public TextMeshProUGUI text;

    public void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        Image[] images = GetComponentsInChildren<Image>();

        foreach (Image img in images)
            if (img.CompareTag("Finish"))
                image = img;

        Refresh();
    }
    public  void Refresh()
    {
        if (PlayerPrefs.HasKey("Save" + save))
        {
            text.text = "Sauvegarde " + (save+1);
            image.color = new Color(1f, 1f, 1f, 1f);
            image.sprite = DataSaver.LoadSprite(Application.persistentDataPath + '/' + save + ".png");
        }
        else 
        {
            text.text = "Sauvegarde vide.";
            image.color = new Color(1f, 1f, 1f, 0f);
        }
    }

    public void SaveClick(int save) 
    {
        DataSaver.Save(save);
        Refresh();
    }
}
