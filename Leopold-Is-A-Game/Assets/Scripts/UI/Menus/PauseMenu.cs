using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    internal static bool isGamePaused = false;

    Animator animator;
    public Fader fader;

    public GameObject options;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (!isGamePaused)
                PauseGame();
            else
                ResumeGame();
        }       
    }

    public void ResumeGame() 
    {
        animator.SetTrigger("Resume");
        isGamePaused = false;
        Time.timeScale = 1f;
    }

    public void PauseGame() 
    {
        isGamePaused = true;
        animator.SetTrigger("Pause");
        Time.timeScale = 0f;
    }

    public void Options() 
    {
        options.SetActive(true);
    }

    public void MainMenuButton() 
    {
        StoryHandler.isFading = true;
        Time.timeScale = 1f;
        StartCoroutine(MainMenu());
    }

    IEnumerator MainMenu() 
    {
        while (!fader.IsOpaque) 
        {
            fader.FadeIn(3f);
            yield return null;
        }
        StoryHandler.isFading = false;
        isGamePaused = false;
        SceneManager.LoadScene("MainMenu");
    }
}
