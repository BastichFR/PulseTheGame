using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject lightSource;
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        lightSource.SetActive(false); // make sure the light source is off at start
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) // toggle the flashlight
        {
            isActive = !isActive;
            lightSource.SetActive(isActive);
        }
    }
}
