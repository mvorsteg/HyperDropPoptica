using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AutoScroll : MonoBehaviour
{
    public float totalScrollTime;
    public Vector3 startPos;
    public Vector3 endPos;

    public GameObject[] winScreens;

    private float elapsedTime;

    private void Start()
    {
        elapsedTime = 0;
        StartCoroutine(End());
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / totalScrollTime);
        elapsedTime += Time.deltaTime;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator End()
    {
        yield return new WaitForSeconds(totalScrollTime);
        for (int i = 0; i < winScreens.Length; i++)
        {
            winScreens[i].SetActive(true);
        }
    }
}