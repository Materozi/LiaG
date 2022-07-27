using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSoundEffect : MonoBehaviour
{

    AudioSource source;
    public AudioClip clip;
    public bool waitForEnd = false;
    public Vector2 Range = new Vector2();

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void PlayRandomSound() 
    {
        if (source.isPlaying && waitForEnd)
            return;

        source.pitch = Random.Range(Range.x, Range.y);
        source.PlayOneShot(clip);
    }
}
