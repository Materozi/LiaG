using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Tomes 
{
    Tome1,
    Tome2,
    Tome3,
}


public class PlayMenu : MonoBehaviour
{
    public MainMenu mainMenu;
    public Fader fader;

    public void BackButton() 
    {
        StartCoroutine(BackCoroutine());
    }

    public void OnEnable()
    {
        //check for finished tomes to unlock the next ones
        if (!PlayerPrefs.HasKey("backTome"))
            return;

        if (PlayerPrefs.GetString("backTome") == "Tome1 (Story)" && !PlayerPrefs.HasKey("tome2Unlocked")) 
        {
            PlayerPrefs.SetInt("tome2Unlocked", 1);
            //play animation
        }
        if (PlayerPrefs.GetString("backTome") == "Tome2 (Story)" && !PlayerPrefs.HasKey("tome3Unlocked"))
        {
            PlayerPrefs.SetInt("tome3Unlocked", 1);
            //play animation
        }
        if (PlayerPrefs.GetString("backTome") == "Tome3 (Story)" && !PlayerPrefs.HasKey("credits"))
        {
            PlayerPrefs.SetInt("credits", 1);
            //play animation
        }
    }

    public void TomeButton(int index)
    {
        StoryHandler.story = Resources.Load<Story>("Tomes/"+((Tomes)index).ToString());

        SituationHandler.dialogIndex = -1;
        StoryHandler.situationIndex  = -1;

        StartCoroutine(StartGame());    
    }

    public void CreditsButton()
    {

    }

    public void Open() 
    {
        StartCoroutine(OpenCoroutine());
    }
    

    IEnumerator OpenCoroutine()
    {
        while (!fader.IsClear)
        {
            fader.UnFade(3);
            yield return null;
        }
    }

    IEnumerator StartGame()
    {
        while (!fader.IsOpaque)
        {
            fader.FadeIn(3);
            yield return null;
        }

        Destroy(GameObject.FindGameObjectWithTag("MusicPlayer"));
        SceneManager.LoadScene("Game");
    }

    IEnumerator BackCoroutine()
    {
        while (!fader.IsOpaque)
        {
            fader.FadeIn(3);
            yield return null;
        }
        // display main menu
        yield return new WaitForSeconds(.2f);
        mainMenu.mainMenu.SetActive(true);
        gameObject.SetActive(false);
        mainMenu.FadeOutScreen();
    }
}
