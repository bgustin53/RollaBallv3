using System.Collections;
using UnityEngine;

/****************************************************************** 
* This script handles player power-ups. When the player collides
* with a power-up object a speed boost is applied to the player.
* The effect lasts for a fixed duration and then reverts to
* normal.  This script is a component of the Player.
*  
* Design by: YourName
* Implementation by: ChatGPT 3.5, OpenAI, October 22, 2024
******************************************************************/

public class PowerUpController : MonoBehaviour
{
    [Header("User Set Properties")]
    [SerializeField] private float speedBoost = 0.5f;   // Percentage speed increase for a speed power-up.
    [SerializeField] private float duration = 5f;       // The duration of the power-up effect in seconds.

    [Header("Drag Player Here")]
    [SerializeField] private PlayerController playerController;

    private Rigidbody playerRigidbody;           // Reference to the player's Rigidbody to modify movement.
    private bool isPowerUpActive;                // A boolean to track whether the power-up is active.
    private float originalSpeed;                 // Store the original speed to revert back after power-up ends.

    // Start is called before the first frame update.
    void Start()
    {
        playerRigidbody = playerController.GetComponent<Rigidbody>();
        originalSpeed = playerController.speed;
        isPowerUpActive = false;
    }

    // This method is called when the player collides with a GameObject.
    // It activates the power-up and applies the effect.
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp") && !isPowerUpActive)
        {
            Destroy(other.gameObject);
            StartCoroutine(PowerUpDuration());
        }
    }

    // This coroutine handles the duration of the power-up.
    // It applies the effect and then waits for the duration to expire before reverting.
    private IEnumerator PowerUpDuration()
    {
        isPowerUpActive = true;

        // Apply the power-up effect: boost player speed
        float boostedSpeed = originalSpeed * (1.0f + speedBoost);
        playerController.speed = boostedSpeed;

        // Wait for the power-up duration to expire
        yield return new WaitForSeconds(duration);

        // Revert the player to the original speed
        playerController.speed = originalSpeed;

        isPowerUpActive = false;
    }
}


