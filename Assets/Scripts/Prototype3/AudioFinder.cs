using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioFinder : MonoBehaviour
{
    public List<AudioSource> audioSourcesInRange = new List<AudioSource>(), 
        activeAudioSources = new List<AudioSource>();

    Vector3 test =  Vector3.zero;

    float detectionDistance = 5, detectionDir, halfScreenHori = 960, halfScreenVer = 540;

    [SerializeField] RectTransform display;
    Vector2 displayPos;

    private void Start()
    {
        detectionDir = 0.5f;
    }

    private void Update()
    {
        CheckAudioPlaying();
    }

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
                //Debug.Log("Noise in Range");
                //Show visualisation of audio on screen

                if (!activeAudioSources.Contains(audioSourcesInRange[i]))
                {
                    activeAudioSources.Add(audioSourcesInRange[i]);
                    GetAudioPos();
                }
            }
        }

        for(int i = 0; i < activeAudioSources.Count; i++)
        {
            if(!activeAudioSources[i].isPlaying)
            {
                Debug.Log("removing from active list: " + activeAudioSources[i]);
                activeAudioSources.Remove(activeAudioSources[i]);
            }
        }
    }

    private void GetAudioPos()
    {
        Debug.Log("Displaying UI");
        AudioSource _playing = activeAudioSources[^1];

        GameObject obj = _playing.gameObject;
        Vector3 direction = obj.transform.position;
        Debug.Log("Audio in dir: " + direction);
        test = direction;

        float zPos = direction.z,
            xPos = direction.x;

        if (_playing.isPlaying)
        {
            if (xPos > detectionDir)
            {
                //Right side of screen
                displayPos = new Vector2(halfScreenHori, zPos*100);
            }
            if (xPos < -detectionDir)
            {
                //Left side of screen
                displayPos = new Vector2(-halfScreenHori, zPos * 100);
            }
            if (zPos < -detectionDir)
            {
                //Bottom of screen
                displayPos = new Vector2(xPos * 100, -halfScreenVer);
            }
            DisplayAudio(displayPos);
        }
    }

    private void DisplayAudio(Vector2 _displayPos)
    {
        display.anchoredPosition = _displayPos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionDistance);
        Gizmos.DrawLine(this.transform.position, test);
    }
}
