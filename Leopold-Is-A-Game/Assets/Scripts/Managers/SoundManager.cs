using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance  = null;

    public AudioSource ambiantEmitter    = null;
    public AudioSource ambiantEmitterBis = null;
    public AudioSource oneShotEmitter    = null;

    // if true, the current played music is on the first source
    public static bool isUsingFirstSource = true;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    public static void PlayDialogSound(AudioClip clip, bool cutAmbiant) 
    {
        // pause music
        if (cutAmbiant) 
        {
            instance.ambiantEmitterBis.volume = 0f;
            instance.ambiantEmitter.volume = 0f;
        }

        // play one shot clip
        instance.StartCoroutine(PlayOneShotSoundAndRestartAmbiant(instance.oneShotEmitter, clip, cutAmbiant));

    }

    public static void ChangeAmbiantSound(AudioClip clip)
    {
        if (isUsingFirstSource)
        {
            if (instance.ambiantEmitter.clip == clip)
                return;
        }
        else
        { 
            if (instance.ambiantEmitterBis.clip == clip)
                return;
        }

        instance.StartCoroutine(LerpSources(instance.ambiantEmitter, instance.ambiantEmitterBis, clip));
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

    static IEnumerator LerpSources(AudioSource source, AudioSource bis, AudioClip clip)
    {
        // flip flop on sources
        float currentTime = 0f;

        float start = .04f;

        if (isUsingFirstSource)
        {
            while (source.volume != 0f)
            {
                //first source
                source.volume = Mathf.Lerp(start, 0f, currentTime);
                source.Stop();
                //second one
                bis.volume = Mathf.Lerp(0f, start, currentTime);

                currentTime += Time.deltaTime * 2f;
                yield return null;
            }
        }
        else 
        {
            while (bis.volume != 0f)
            {
                //first source
                bis.volume = Mathf.Lerp(start, 0f, currentTime);
                bis.Stop();
                //second one
                source.volume = Mathf.Lerp(0f, start, currentTime);

                currentTime += Time.deltaTime;
                yield return null;
            }
        }
        isUsingFirstSource = !isUsingFirstSource;

        if (isUsingFirstSource)
        {
            source.clip = clip;
            source.Play();
        }
        else
        {
            bis.clip = clip;
            bis.Play();
        }
    }

    static IEnumerator PlayOneShotSoundAndRestartAmbiant(AudioSource source, AudioClip clip, bool cutAmbiant) 
    {
        source.clip = clip;
        source.Play();

        while (source.isPlaying) 
            yield return null;

        if (cutAmbiant)
            instance.StartCoroutine(FadeInSource(instance.ambiantEmitter));
    }

    static IEnumerator FadeInSource(AudioSource source) 
    {
        float sourceVolume = 0f;
        float currentTime = 0;
        while (sourceVolume < .04f)
        {
            currentTime += Time.deltaTime;
            if (isUsingFirstSource)
            {
                source.volume = Mathf.Lerp(0f, .04f, currentTime);
                sourceVolume = source.volume;
            }
            else 
            {
                instance.ambiantEmitterBis.volume = Mathf.Lerp(0f, .04f, currentTime);
                sourceVolume = instance.ambiantEmitterBis.volume;
            }
            yield return null;
        }
    }
}
