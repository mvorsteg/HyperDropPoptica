using UnityEngine;

public class AutoScroll : MonoBehaviour
{
    public float totalScrollTime;
    public Vector3 startPos;
    public Vector3 endPos;

    private float elapsedTime;

    private void Start()
    {
        elapsedTime = 0;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / totalScrollTime);
        elapsedTime += Time.deltaTime;
    }
}