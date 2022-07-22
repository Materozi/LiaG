using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Fader fader;
    public Fader fader2;
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
        // display options menu
    }
    IEnumerator PlayCoroutine() 
    {
        while (!fader.IsOpaque)
        {
            fader.FadeIn();
            yield return null;
        }
        
        yield return new WaitForSeconds(.6f);

        while (!fader2.IsOpaque)
        {
            fader2.FadeIn();
            yield return null;
        }
        
        yield return new WaitForSeconds(1f);

        Destroy(GameObject.FindGameObjectWithTag("MusicPlayer"));
        SceneManager.LoadScene("Game");
    }

    IEnumerator StartCoroutine() 
    {
        while (!fader2.IsClear)
        {
            fader2.UnFade(3);
            yield return null;
        }
    }


    private void Start()
    {
        StartCoroutine(StartCoroutine());
    }
}
