using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    public AudioSource ambiantEmitter = null;
    public AudioSource oneShotEmitter = null;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    public static void PlayDialogSound(AudioClip clip) 
    {
        // pause music
        instance.StartCoroutine(FadeOutSource(instance.ambiantEmitter));
        // play one shot clip
        instance.StartCoroutine(PlayOneShotSoundAndRestartAmbiant(instance.oneShotEmitter, clip));

    }

    static IEnumerator FadeOutSource(AudioSource source) 
    {
            float currentTime = 0;
            float start = source.volume;
            while (currentTime < 1f)
            {
                currentTime += Time.deltaTime;
                source.volume = Mathf.Lerp(start, 0f, currentTime);
                yield return null;
            }
            yield break;
    }

    static IEnumerator PlayOneShotSoundAndRestartAmbiant(AudioSource source, AudioClip clip) 
    {
        source.clip = clip;
        source.Play();

        while (source.isPlaying) 
            yield return null;

        instance.StartCoroutine(FadeInSource(instance.ambiantEmitter));
    }

    static IEnumerator FadeInSource(AudioSource source) 
    {
        float currentTime = 0;
        float start = source.volume;
        while (currentTime < 1f)
        {
            currentTime += Time.deltaTime;
            source.volume = Mathf.Lerp(start, .1f, currentTime);
            yield return null;
        }
        yield break;
    }
}
