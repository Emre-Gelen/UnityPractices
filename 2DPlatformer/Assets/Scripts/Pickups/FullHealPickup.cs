using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class inherits from the Pickup class and will heal the player when picked up
/// </summary>
public class FullHealPickup : Pickup
{
    /// <summary>
    /// Description:
    /// Function called when this pickup is picked up
    /// Heals the health attatched to the collider that picks this up
    /// Input: 
    /// Collider2D collision
    /// Return: 
    /// void (no return)
    /// </summary>
    /// <param name="collision">The collider that is picking up this pickup</param>
    public override void DoOnPickup(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.gameObject.GetComponent<Health>() != null)
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            playerHealth.ReceiveHealing(playerHealth.maximumHealth);
            base.DoOnPickup(collision);
        }
    }
}
