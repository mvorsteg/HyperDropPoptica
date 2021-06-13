using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 5;
    private int currHealth;
    public HealthBar healthBar;

    private bool isActive;
    private bool canThrow = true;

    public Projectile projectile;
    public float force = 10f;

    private PlayerMovement playerMovement;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        currHealth = maxHealth;   
    }

    private void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        currHealth = currHealth - amount;
        healthBar.SetHealth(currHealth);
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
            animator.SetTrigger("Throw");
            Vector2 dir = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            
            projectile.gameObject.SetActive(true);
            projectile.StartCoroutine(projectile.Throw(dir, force, transform.position));
        }
    }

    public void PickUpProjectile()
    {
        projectile.gameObject.SetActive(false);
        animator.SetTrigger("Pickup");
        canThrow = true;
    }
}