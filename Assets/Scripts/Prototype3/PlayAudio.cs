using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] AudioSource clip;

    public void AudioPlayer(bool playAudio)
    {
        if(playAudio)
        {
            if (!clip.isPlaying)
            {
                clip.Play();
            }
        }
    }
}
