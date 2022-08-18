using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OptionsMenu : MonoBehaviour
{
    CanvasGroup background;

    public Toggle toggle;
    public Slider music;
    public Slider bruitages;

    public static bool AutoSave = true;
    public static float BruitageVolume = 1f;
    public static float MusicsVolume = 1f;

    private void Awake() => background = GetComponent<CanvasGroup>();


    private void OnEnable()
    {
        background.alpha = 0;
        StartCoroutine(Fade(2.5f));
        RefreshUI();
    }

    public void RefreshUI()
    {
        toggle.isOn     = AutoSave;
        music.value     = MusicsVolume;
        bruitages.value = BruitageVolume;
    }

    public static void LoadOptions()
    {
        AutoSave       = Convert.ToBoolean(PlayerPrefs.GetInt("autosave"));
        MusicsVolume   = PlayerPrefs.GetFloat("musics");
        BruitageVolume = PlayerPrefs.GetFloat("bruitages");
    }

    public static void SaveOptions() 
    {
        PlayerPrefs.SetInt("autosave", Convert.ToInt32(AutoSave));
        PlayerPrefs.SetFloat("musics", MusicsVolume);
        PlayerPrefs.SetFloat("bruitages", BruitageVolume);
    }

    public void SetAutoSave(bool active)
    {
        AutoSave = toggle.isOn;
    }

    public void SetMusicValue() 
    {
        MusicsVolume = music.value;
    }

    public void SetBruitageValue()
    {
        BruitageVolume = bruitages.value;
    }

    public void Hide()
    {
        SaveOptions();
        background.alpha = 1;
        StartCoroutine(Fade(-2.5f));
    }

    IEnumerator Fade(float ratio) 
    {
        if (ratio > 0)
        {
            while (background.alpha < 1) 
            {
                background.alpha += Time.unscaledDeltaTime * ratio;
                yield return null;
            }
        }
        else 
        {
            while (background.alpha > 0)
            {
                background.alpha += Time.unscaledDeltaTime * ratio;
                yield return null;
            }
            gameObject.SetActive(false);
        }
    }
}
