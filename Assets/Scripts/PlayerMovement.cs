using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject cursor;

    public float speed = 5f;
    public bool isActive;

    private Vector2 movement;
    private Vector2 aiming;

    private Rigidbody2D rb;
    private Player player;

    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
       player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // Input
        if (isActive)
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            // aiming
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = Input.mousePosition - pos;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //Debug.Log(angle * Mathf.Deg2Rad);
            cursor.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 

            // projectile
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                player.ThrowProjectile(angle);
            }

        }
        else
        {
            movement = Vector2.Lerp(movement, Vector2.zero, Time.deltaTime * 8);
        }
    }

    private void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}