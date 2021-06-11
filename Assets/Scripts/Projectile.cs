using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float stopThreshold = 0.01f;
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

    // figure out why velocity doesnt get updated at all
        while (rb.velocity.magnitude > stopThreshold)
        {
            Debug.Log(rb.velocity.magnitude);
            yield return null;
        }

        gameObject.layer = LayerMask.NameToLayer("Default");
    }    
}