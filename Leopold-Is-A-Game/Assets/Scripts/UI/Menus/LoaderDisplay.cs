using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LoaderDisplay : MonoBehaviour
{
    public int value = 0;

    public TMPro.TextMeshProUGUI text;
    public Image img;
    public Image border;

    Image bg;

    public void Start()
    {
        bg = GetComponent<Image>();
        Unlight();
    }

    public void Hilight() 
    {
        bg.sprite = Resources.Load<Sprite>("UI/panel_palmer");
        border.rectTransform.localScale = new Vector2(1f, 1f);
    }

    public void Unlight()
    {
        bg.sprite = Resources.Load<Sprite>("UI/panel_simple");
        border.rectTransform.localScale = new Vector2(.0f, .0f);
    }

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
        Destroy(GameObject.FindGameObjectWithTag("MusicPlayer"));
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
        PauseMenu.isGamePaused = false;
    }
}
