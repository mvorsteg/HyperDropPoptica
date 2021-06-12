using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float stopThreshold = 0.01f;
    public float minTravelTime = 0f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();    
    }


    public IEnumerator Throw(Vector2 angle, float force, Vector3 startingPosition)
    {
        gameObject.layer = LayerMask.NameToLayer("PlayerProjectile");
        transform.position = startingPosition;
        rb.velocity = Vector2.zero;
        rb.AddForce(force * angle);

        float elapsedTime = 0;
        while (rb.velocity.magnitude > stopThreshold || elapsedTime <= minTravelTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        gameObject.layer = LayerMask.NameToLayer("Default");
    }    

    private void OnCollisionEnter2D(Collision2D other)
    {
        Player p = other.transform.GetComponent<Player>();
        if (p != null)
        {
            p.PickUpProjectile();
        }
    }
}