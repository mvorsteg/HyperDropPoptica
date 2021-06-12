using UnityEngine;
using System.Collections;

// Put this on a gameobject to kill it after the specified time
public class Destructor : MonoBehaviour
{
    public float destructTime;

    void Awake()
    {
        StartCoroutine(DestructTimer());
    }

    private IEnumerator DestructTimer()
    {
        yield return new WaitForSeconds(destructTime);
        Destroy(gameObject);
    }
}