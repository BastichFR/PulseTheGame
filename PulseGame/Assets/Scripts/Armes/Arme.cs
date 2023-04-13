using UnityEngine;
using System.Collections;

public class Arme : Player
{
    public GameObject ballePrefab;          // préfab de la balle
    public Transform pointDeTir;            // point d'ou part la balle
    public float forceDeTir = 5000f;        // vecteur de force de la balle
       
    public int chargeurCapacity;            // camacité en balle du chargeur
    public int nombreChargeurs;             // nombre de chargeurs
    public int chargeurActuel;              // chargeur actuel
       
    public int degats;                      // dégats de l'arme
       
    public float fireRate;                  // cadence de tire
    protected bool semiAutomatic = false;   // tire en semi-automatic (rester appuyé)
    protected bool canFire = true;          // peut tirer
       
    public float reloadTime;                // temps de reload
    protected bool isReloading = false;     // est en train de reload


    protected virtual void Start()    
    {
        chargeurActuel = chargeurCapacity;   // mise en place du chargeur
    }

    protected virtual void Update()
    {
        // si on appuie pour tirer, qu'on est pas en train de reload et qu'il nous reste des balles
        if (Input.GetButtonDown("Fire1") && canFire && !isReloading && chargeurActuel > 0 && nombreChargeurs > 0)
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

        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            StartCoroutine(Reload());
        }
    }

    protected virtual void Tirer()
    {
        chargeurActuel -= 1;
        GameObject balle = Instantiate(ballePrefab, pointDeTir.position, pointDeTir.rotation);
        Rigidbody rb = balle.GetComponent<Rigidbody>();
        rb.AddForce(pointDeTir.forward * forceDeTir);
        Destroy(balle, 0.3f);
    }

    protected virtual IEnumerator Fire()
    {
        canFire = false;
        Tirer();
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

    protected virtual IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        chargeurActuel = chargeurCapacity;
        nombreChargeurs -= 1;
        isReloading = false;
    }
}