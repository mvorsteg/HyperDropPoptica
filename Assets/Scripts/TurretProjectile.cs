using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    public int damage = 1;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Player p = other.transform.GetComponent<Player>();
        if (p != null)
        {
            p.TakeDamage(damage);
        }   
    }
}