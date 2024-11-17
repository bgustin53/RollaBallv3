using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*****************************************************************
 * This script is a component of the Lightning GameObject which
 * is a Directional Light.  It purpose is to create a ligntning
 * effect at random intervals.
 * 
 * Author: Bruce Gustin
 * 10/19/2024
*******************************************************************/

public class LightningRandomizer : MonoBehaviour
{
    private Light lightning;       // Light component to simulate the lightning effect
    private AudioSource audioSource;  // AudioSource component for the lightning sound effect

    // References to the Light and AudioSource components are initialized
    void Start()
    {
        // Get the Light component attached to this GameObject
        lightning = GetComponent<Light>();

        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    // Continually check if a random condition is met and triggers the lightning flash and sound
    void Update()
    {
        // Generate a random number between 0.0 and 1.0. If the number is less than 0.001 (0.01% chance)
        // and the audio is not currently playing, trigger the lightning flash and sound
        if (Random.Range(0.0f, 1.0f) < .001f && !audioSource.isPlaying)
        {
            // Set the light intensity to 15 to simulate a lightning flash
            lightning.intensity = 3;

            // Play the lightning sound effect
            audioSource.Play();

            // Invoke the LightningStrike method after 5.15 seconds to turn off the light
            Invoke("LightningStrike", .15f);
        }
    }

    // This method will add additional lightning strikes at each invoke, and then 
    private void LightningStrike()
    {
        {
            // Randomly decide whether to add more strikes (e.g., simulate flickering lightning)
            if (Random.Range(0.0f, 1.0f) < 0.9f)
            {
                // If another strike should occur, set the light intensity back to 5
                lightning.intensity = 5;

                // Schedule another flicker of lightning after a brief delay
                Invoke("LightningStrike", .1f); // Adjust timing to control the flicker effect
            }
            else
            {
                // Otherwise, turn off the lightning by setting the intensity to 0
                lightning.intensity = 0;
            }
        }
    }
}
