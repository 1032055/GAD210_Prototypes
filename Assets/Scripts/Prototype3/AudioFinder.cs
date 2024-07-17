using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioFinder : MonoBehaviour
{
    public List<AudioSource> audioSourcesInRange = new List<AudioSource>();

    float detectionDistance = 5;

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent<AudioSource>(out AudioSource _sourceCheckA);
        if(_sourceCheckA)
        {
            AddToList(_sourceCheckA);
        }

        _sourceCheckA = null;
    }

    private void OnTriggerExit(Collider other)
    {
        other.TryGetComponent<AudioSource>(out AudioSource _sourceCheckR);
        if (_sourceCheckR)
        {
            RemoveFromList(_sourceCheckR);
        }

        _sourceCheckR = null;
    }

    private void AddToList(AudioSource _sourceA)
    {
        Debug.Log("Adding to List: " + _sourceA);
        audioSourcesInRange.Add(_sourceA);
    }

    private void RemoveFromList(AudioSource _sourceR)
    {
        Debug.Log("Removing from List: " + _sourceR);
        audioSourcesInRange.Remove(_sourceR);
    }

    private void CheckAudioPlaying()
    {
        for(int i = 0; i < audioSourcesInRange.Count; i++)
        {
            if(audioSourcesInRange[i].isPlaying)
            {
                Debug.Log("Noise in Range");
                //Show visualisation of audio on screen
                ShowAudio(audioSourcesInRange[i]);
            }
        }
    }

    private void ShowAudio(AudioSource _activeAudio)
    {
        Debug.Log("Displaying UI");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionDistance);
    }
}
