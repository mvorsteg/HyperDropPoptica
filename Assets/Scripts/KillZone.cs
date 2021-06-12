using UnityEngine;

public class KillZone : MonoBehaviour
{
    // kill the player if they enter the killzone
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player p = other.transform.GetComponent<Player>();
        if (p != null)
        {
            p.Die();
        }    
    }   
}