using UnityEngine;
using System.Collections;

public class Arme : Player
{
    public GameObject ballePrefab;          // préfab de la balle
    public Transform pointDeTir;            // point d'ou part la balle
    public float forceDeTir = 5000f;        // vecteur de force de la balle
    
    public int chargeurCapacity;            // capacité en balle du chargeur
    public int nombreChargeurs;             // nombre de chargeurs
    public int chargeurActuel;              // chargeur actuel
    
    public int degats;                      // dégâts de l'arme
    
    protected float fireRate;                  // cadence de tir
    protected bool semiAutomatic;   // tire en semi-automatic (rester appuyé)
    protected bool canFire = true;          // peut tirer (utilisé lorsqu'on vient de tirer pour le fireRate)
    
    protected float reloadTime;                // temps de reload
    protected bool isReloading = false;     // est en train de reload
    
    private float timeSinceLastShot;   // temps écoulé depuis le dernier tir
    
    protected AudioSource WeaponFire;
    protected AudioSource WeaponReload;
    protected AudioSource WeaponEmpty;
    
    protected int totalMun; // nombre total de munitions
    
    protected virtual void Start()    
    {
        WeaponFire   = GameObject.Find("AudioList/WeaponFire").GetComponent<AudioSource>();
        WeaponReload = GameObject.Find("AudioList/WeaponReload").GetComponent<AudioSource>();
        WeaponEmpty  = GameObject.Find("AudioList/WeaponEmpty").GetComponent<AudioSource>();
        
        timeSinceLastShot = 0f;
        
        chargeurActuel = chargeurCapacity;   // mise en place du chargeur
        totalMun = chargeurCapacity * nombreChargeurs; // calcul du nombre total de munitions
    }
    
    protected virtual void Update()
    {
        Debug.Log("capacity :" + chargeurActuel + " - TotalMun :" + totalMun);

        timeSinceLastShot += Time.deltaTime;  // met à jour le temps écoulé depuis le dernier tir
        
        if (Input.GetButton("Fire1") && canFire && !isReloading)
        {
            if (semiAutomatic)
            {
                Tirer();
            }
            else
            {
                StartCoroutine(Fire());
            }
        }
        
        if (Input.GetKeyDown(KeyCode.R) && !isReloading && chargeurActuel < chargeurCapacity && totalMun > 0)
        {
            StartCoroutine(Reload());
        }
    }
    
    protected virtual void Tirer()
    {
        if(chargeurActuel > 0)
        {
            if (timeSinceLastShot >= fireRate)  // vérifie si la cadence de tir est respectée
            {
                WeaponFire.PlayOneShot(WeaponFire.clip);
                timeSinceLastShot = 0f;  // remet à zéro le temps écoulé depuis le dernier tir
                chargeurActuel -= 1;
                GameObject balle = Instantiate(ballePrefab, pointDeTir.position, pointDeTir.rotation);
                Rigidbody rb = balle.GetComponent<Rigidbody>();
                rb.AddForce(pointDeTir.forward * forceDeTir);
                Destroy(balle, 0.3f);
                
            }
        }
        else
        {
            if (timeSinceLastShot >= fireRate)  // vérifie si la cadence de tir est respectée
            {
                timeSinceLastShot = 0f;
                WeaponEmpty.PlayOneShot(WeaponEmpty.clip);
            }
        }
    }

    protected virtual IEnumerator Fire()
    {
        canFire = false;
        while (Input.GetButton("Fire1") && chargeurActuel > 0 && nombreChargeurs > 0)
        {
            Tirer();
            yield return new WaitForSeconds(fireRate);
        }
        canFire = true;
    }

    protected virtual IEnumerator Reload()
    {
        isReloading = true;
        WeaponReload.Play();
        yield return new WaitForSeconds(reloadTime);

        int newChargeur = chargeurCapacity - chargeurActuel;
        if(newChargeur > totalMun)
        {
            chargeurActuel = totalMun;
            totalMun = 0;
        }
        else
        {
            totalMun -= newChargeur;
            chargeurActuel = chargeurCapacity;
        }
        isReloading = false;
    }
}