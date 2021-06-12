using UnityEngine;
using System.Collections;

public class Beater : MonoBehaviour
{
    public float bpm;
    private float beatDur;

    void Start()
    {
        beatDur = 60 / bpm;
        StartCoroutine(Beats());
    }

    private IEnumerator Beats()
    {
        while (true)
        {
            yield return new WaitForSeconds(beatDur);
            BroadcastMessage("PerformBeat");
        }
    }
}