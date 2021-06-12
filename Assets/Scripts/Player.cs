using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 100;
    private float currHealth;

    private bool isActive;
    private bool canThrow = true;

    public Projectile projectile;
    public float force = 10f;

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        currHealth = maxHealth;   
    }

    private void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        currHealth = Mathf.Max(0, currHealth - amount);
        if (currHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        SetActive(false);
    }

    public void SetActive(bool active)
    {
        isActive = active;
        playerMovement.isActive = active;
    }   

    public void ThrowProjectile(float angle)
    {
        if (canThrow)
        {
            canThrow = false;
            Vector2 dir = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            
            projectile.gameObject.SetActive(true);
            projectile.StartCoroutine(projectile.Throw(dir, force, transform.position));
        }
    }

    public void PickUpProjectile()
    {
        projectile.gameObject.SetActive(false);
        canThrow = true;
    }
}