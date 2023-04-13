using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private GameObject lightSource; 
    public AudioSource soundEffect;
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        lightSource = GameObject.FindWithTag("flashlight");
        lightSource.SetActive(isActive); // make sure the light source is off at start
        soundEffect = soundEffect = GameObject.Find("FlashSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) // toggle the flashlight
        {
            isActive = !isActive;
            lightSource.SetActive(isActive);
            soundEffect.Play(); 
        }
    }
}
