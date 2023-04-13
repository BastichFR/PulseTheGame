using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Team {
        Team1,
        Team2
    }

    protected Team team;

    int currentHealth = 125;
    private GameObject flashlight; // assign the flashlight GameObject in the Inspector

    // Start is called before the first frame update
    void Start()
    {
        flashlight = GameObject.FindWithTag("flashlight");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) // toggle the flashlight
        {
            flashlight.SetActive(!flashlight.activeSelf);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // Détruire l'objet
        Destroy(gameObject);
    }
}
