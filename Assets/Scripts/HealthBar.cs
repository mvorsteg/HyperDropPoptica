using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image[] hearts;
    public Color fullColor;
    public Color emptyColor;

    private void Awake()
    {
        hearts = GetComponentsInChildren<Image>();
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].color = fullColor;
        }   
    }

    public void SetHealth(int amount)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].color = amount > i ? fullColor : emptyColor;
        }
    }
}