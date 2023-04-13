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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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