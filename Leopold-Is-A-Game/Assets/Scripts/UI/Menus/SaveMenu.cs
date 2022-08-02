using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMenu : MonoBehaviour
{
    public GameObject buttons;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Open()
    {
        ScreenCapture.CaptureScreenshot("tempSC.png");
        animator.SetTrigger("Open");
        buttons.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Close() 
    {
        animator.SetTrigger("Close");
    }

    public void Disable()
    {
        Time.timeScale = 1f;
        buttons.SetActive(false);
    }
}
