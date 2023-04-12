using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 5f; // adjust this to control the speed of the object
    public GameObject flashlight; // assign the flashlight GameObject in the Inspector

    // Start is called before the first frame update
    void Start()
    {
        flashlight = GameObject.FindWithTag("flashlight");
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = Input.mousePosition; // récupère la position de la souris
        mousePos.z = 10; // définit la distance entre la caméra et la souris
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(mousePos); // convertit la position de la souris en coordonnées du monde

        Vector3 direction = targetPos - transform.position; // calcule la direction entre le personnage et la position de la souris
        direction.y = 0; // ne prend pas en compte la direction verticale
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), speed * Time.deltaTime); // dirige le personnage vers la position de la sourissZZZ
        
        if (Input.GetKey(KeyCode.Z)) // move up
        {
            Vector3 movement = new Vector3(0, 0, speed * Time.deltaTime);
            transform.Translate(movement, Space.World); // move the object in the direction of the movement vector
        }

        if (Input.GetKey(KeyCode.Q)) // move left
        {
            Vector3 movement = new Vector3(-speed * Time.deltaTime, 0, 0);
            transform.Translate(movement, Space.World); // move the object in the direction of the movement vector
        }

        if (Input.GetKey(KeyCode.S)) // move back
        {
            Vector3 movement = new Vector3(0, 0, -speed * Time.deltaTime);
            transform.Translate(movement, Space.World); // move the object in the direction of the movement vector
        }

        if (Input.GetKey(KeyCode.D)) // move right
        {
            Vector3 movement = new Vector3(speed * Time.deltaTime, 0, 0);
            transform.Translate(movement, Space.World); // move the object in the direction of the movement vector
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse1)) // toggle the flashlight
        {
            flashlight.SetActive(!flashlight.activeSelf);
        }
    }
}
