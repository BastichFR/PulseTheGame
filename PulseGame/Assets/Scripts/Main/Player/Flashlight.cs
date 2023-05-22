using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Flashlight : MonoBehaviourPunCallbacks
{
    private GameObject lightSource; 
    private AudioSource soundEffect;
    private bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {
        lightSource = GameObject.FindWithTag("flashlight");
        lightSource.SetActive(isActive); // make sure the light source is off at start
        soundEffect = GameObject.Find("FlashSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {    
            if (Input.GetKeyDown(KeyCode.Mouse1)) // toggle the flashlight
            {
                soundEffect.Play();
                isActive = !isActive;
                lightSource.SetActive(isActive);
            }
        }
    }
}
