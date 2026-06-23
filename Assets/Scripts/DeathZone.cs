using UnityEngine;

// Place this as an invisible trigger zone below the screen.
// When the player ball falls into it, it triggers Game Over.
public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if what entered is the player
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.TriggerDeath();
        }
    }
}