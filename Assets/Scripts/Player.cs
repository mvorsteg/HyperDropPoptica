using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isActive;

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();    
    }

    private void Update()
    {
        
    }

    public void SetActive(bool active)
    {
        isActive = active;
        playerMovement.isActive = active;
    }   
}