using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPunCallbacks
{
    public enum Team {
        Team1,
        Team2
    }

    public Team team = Team.Team1;
    public string NickName;

    int currentHealth = 125;

    public void TakeDamage(int amount)
    {
        if(photonView.IsMine){
            currentHealth -= amount;

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        // Détruire l'objet
        Destroy(gameObject);
    }
}