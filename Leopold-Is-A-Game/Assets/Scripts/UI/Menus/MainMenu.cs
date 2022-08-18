using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Fader fader;
    public Fader fader2;

    public PlayMenu playMenu;
    public GameObject optionsMenu;

    public GameObject mainMenu = null;
    

    
    public void Play() 
    {
        StartCoroutine(PlayCoroutine());
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
    }

    public void Options() 
    {
        optionsMenu.SetActive(true);
    }

    IEnumerator PlayCoroutine() 
    {
        while (!fader.IsOpaque)
        {
            fader.FadeIn();
            yield return null;
        }
        
        yield return new WaitForSeconds(.3f);

        while (!fader2.IsOpaque)
        {
            fader2.FadeIn();
            yield return null;
        }
        yield return new WaitForSeconds(.3f);
        mainMenu.SetActive(false);
        playMenu.gameObject.SetActive(true);
        playMenu.Open();
    }

    IEnumerator StartCoroutine() 
    {
        while (!fader2.IsClear && !fader.IsClear)
        {
            fader2.UnFade(3);
            fader.UnFade(3);
            yield return null;
        }
    }

    public void FadeOutScreen() => StartCoroutine(StartCoroutine());
    
    private void Start() 
    {
       FadeOutScreen();
       OptionsMenu.LoadOptions();
    }
}
