using UnityEngine;

public class BoostSpeed : MonoBehaviour
{
    public float speedBoostAmount = 2f;  // Boost multiplier (e.g., 2x speed)
    public float boostDuration = 5f;     // Duration of the speed boost (in seconds)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the TrainAwareMovement script from the player
            TrainAwareMovement playerMovement = other.GetComponent<TrainAwareMovement>();

            if (playerMovement != null)
            {
                // Apply the speed boost to the player
                playerMovement.ApplySpeedBoost(speedBoostAmount, boostDuration);

                // Destroy the boost object after use
                Destroy(gameObject);
            }
        }
    }
}
