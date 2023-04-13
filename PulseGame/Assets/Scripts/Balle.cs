using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : Arme
{    
    private void OnCollisionEnter(Collision collision)
    {
        // Si la balle touche un joueur
        if (collision.gameObject.CompareTag("Player"))
        {
            // On récupère le script du joueur
            Player player = collision.gameObject.GetComponent<Player>();
            
            // Si le joueur a un script Joueur, on lui inflige des dégâts
            if (player != null && player.team != this.team)
            {
                player.TakeDamage(degats);
            }
        }
        
        // La balle est détruite si elle touche un objet
        Destroy(gameObject);
    }
}
