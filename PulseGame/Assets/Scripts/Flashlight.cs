using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject lightSource;
    public float batteryLife = 10f;
    public float batteryDrainRate = 0.1f;
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        lightSource.SetActive(false); // make sure the light source is off at start
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive && batteryLife > 0f) // check if the flashlight is active and still has battery life left
        {
            batteryLife -= batteryDrainRate * Time.deltaTime; // reduce the battery life over time
            if (batteryLife <= 0f)
            {
                batteryLife = 0f; // make sure the battery life can't go negative
                isActive = false; // turn off the flashlight if the battery dies
                lightSource.SetActive(false); // turn off the light source
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1)) // toggle the flashlight
        {
            isActive = !isActive;
            lightSource.SetActive(isActive);
        }
    }
}