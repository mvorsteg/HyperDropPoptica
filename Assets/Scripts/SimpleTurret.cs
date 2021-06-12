using UnityEngine;
using System.Collections;

public class SimpleTurret : MonoBehaviour
{
    public GameObject turretProjectile;
    public float projectileSpeed = 50;
    public bool followBeats = true;
    public bool followMarkers = true;
    private Rigidbody2D rb;
    private int health;
    private TurretInstruction[] instructions;
    private int instructNum;

    // Called by TurretController at the beginning
    public void BeginTurret(TurretInstruction[] instructs)
    {
        rb = GetComponent<Rigidbody2D>();
        instructions = instructs;
    }

    // Called on every beat (if followBeats is true and Beater.beatEvents == true)
    public void PerformBeat()
    {
        if (followBeats)
        {
            TurretInstruction currInst = instructions[instructNum];
            InstantRotate(currInst.rotation);
            FireProjectile(currInst.numProjectiles, currInst.spread, currInst.spreadOffset);
            instructNum = (instructNum + 1) % instructions.Length;
        }
    }

    // Called on every marker (if followBeats is true and Beater.markerEvents == true)
    public void PerformMarker()
    {
        if (followMarkers)
        {
            TurretInstruction currInst = instructions[instructNum];
            InstantRotate(currInst.rotation);
            FireProjectile(currInst.numProjectiles, currInst.spread, currInst.spreadOffset);
            instructNum = (instructNum + 1) % instructions.Length;
        }
    }


    // Rotates the turret instantly as specified by degrees
    private void InstantRotate(float degrees)
    {
        rb.SetRotation(rb.rotation + degrees);
    }

    /*
        numProjectiles: number of projectiles to be fired when this method is called
        spread: angle in degrees. Projectiles will be spaced out evenly within this angle
        spreadOffset: angle in degrees. The spread will be rotated by this amount.

        Please note that this will be relative to the turret's current rotation.
        
        Example - Shooting in four directions due north, due south, due east, due west:
        FireProjectile(4, 270, 45)
        Example - Shooting in four directions northeast, southeast, southwest, northwest:
        FireProjectile(4, 270, 0)
    */
    private void FireProjectile(int numProjectiles, float spread, float spreadOffset)
    {
        GameObject currProjectile;
        for (int i = 0; i < numProjectiles; i++)
        {
            float projAngle = spreadOffset - spread / 2 + spread / (numProjectiles - 1) * i;
            currProjectile = Instantiate(turretProjectile, rb.position, Quaternion.Euler(0, 0, rb.rotation + projAngle));
            currProjectile.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, projectileSpeed), ForceMode2D.Impulse);
        }
    }

}