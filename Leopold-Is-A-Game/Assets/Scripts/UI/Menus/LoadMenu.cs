using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMenu : MonoBehaviour
{

    public GameObject buttons;

    Animator animator;

    void Start() => animator = GetComponent<Animator>();


    public void OpenLoads()
    {
        buttons.SetActive(true);
        animator.SetTrigger("Open");
    }

    public void CloseLoad() => animator.SetTrigger("Close");

    private void Disable()
    {
        Time.timeScale = 1f;
        buttons.SetActive(false);
    }
}
