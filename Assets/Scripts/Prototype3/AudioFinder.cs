using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioFinder : MonoBehaviour
{
    List<AudioSource> audioSourcesInRange = new List<AudioSource>();

    float detectionDistance = 5;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void AddToList()
    {

    }

    private void CheckAudioPlaying()
    {
        for(int i = 0; i < audioSourcesInRange.Count; i++)
        {
            if(audioSourcesInRange[i].isPlaying)
            {
                //Show visualisation of audio on screen
                ShowAudio(audioSourcesInRange[i]);
            }
        }
    }

    private void ShowAudio(AudioSource _activeAudio)
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionDistance);
    }
}
