using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    private List<EventInstance> eventInstances;
    public static AudioManager instance { get; private set; }

    private EventInstance bgEventInstance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one audio manager in this scene");
        }
        instance = this;

        eventInstances = new List<EventInstance>();
    }

    private void Start()
    {
        InitializeMusic(FMODEvents.instance.bgMusic); 
    }

    private void InitializeMusic(EventReference bgEventReference)
    {
        bgEventInstance = CreateInstance(bgEventReference);
        bgEventInstance.start();
    }

    public void PlayeOneShot(EventReference sound)
    {
        RuntimeManager.PlayOneShot(sound);
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }

    private void CleanUp()
    {
        foreach (EventInstance eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
    }

    private void OnDestroy()
    {
        CleanUp();
    }
}
