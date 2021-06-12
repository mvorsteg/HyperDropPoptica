using UnityEngine;
using System.Collections;

public class Beater : MonoBehaviour
{
    public bool beatEvents;
    public bool markerEvents;
    private FMOD.Studio.EventInstance instance;
    private BeatSystem bS;

    void Start()
    {
        bS = GetComponent<BeatSystem>();   
        StartMusic();
    }

    public void StartMusic()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/HyperpopSong");
        instance.start();
        bS.AssignBeatEvent(instance);
        StartCoroutine(Beats());
        StartCoroutine(Markers());
    }

    public void StopMusic()
    {
        bS.StopAndClear(instance);
    }

    // Handles sending the message to all the children whenever there's a beat
    private IEnumerator Beats()
    {
        while (true)
        {
            int currentBeat = BeatSystem.beat;
            yield return new WaitUntil(() => BeatSystem.beat != currentBeat);
            if (beatEvents)
            {
                BroadcastMessage("PerformBeat");
            }
        }
    }

    // Handles sending the message to all the children whenever there's a marker
    private IEnumerator Markers()
    {
        while (true)
        {
            string currentMarker = BeatSystem.marker;
            yield return new WaitUntil(() => BeatSystem.marker != currentMarker);
            if (BeatSystem.marker == "StopBeats")
            {
                Debug.Log("stopbeats");
                beatEvents = false;
            }
            else if (BeatSystem.marker == "StartBeats")
            {
                Debug.Log("startbeats");
                beatEvents = true;
            }
            else if (markerEvents)
            {
                BroadcastMessage("PerformMarker");
            }
        }
    }
}