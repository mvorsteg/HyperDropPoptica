using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTurret : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        try
        {
            SimpleTurret turret = other.GetComponent<SimpleTurret>();
            Destroy(turret);
        }
        catch
        {
            
        }
    }   
}
