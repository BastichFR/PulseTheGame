using UnityEngine;
using System.Collections;

public class UZI : Arme
{
    private float timeSinceLastShot = 0f;

    protected override void Start() // Start is called before the first frame update
    {
        chargeurCapacity = 20;
        nombreChargeurs = 5;
        degats = 33;
        fireRate = 0.06f;
        reloadTime = 1f;

        semiAutomatic = true;

        base.Start();  // appelle la méthode Start() de la classe parent
    }

    protected override void Update()
    {
        timeSinceLastShot += Time.deltaTime;  // met à jour le temps écoulé depuis le dernier tir

        if (Input.GetButton("Fire1") && canFire && !isReloading && chargeurActuel > 0 && nombreChargeurs > 0)
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

    protected override void Tirer()
    {
        if (timeSinceLastShot >= fireRate)  // vérifie si la cadence de tir est respectée
        {
            timeSinceLastShot = 0f;  // remet à zéro le temps écoulé depuis le dernier tir
            chargeurActuel -= 1;
            GameObject balle = Instantiate(ballePrefab, pointDeTir.position, pointDeTir.rotation);
            Rigidbody rb = balle.GetComponent<Rigidbody>();
            rb.AddForce(pointDeTir.forward * forceDeTir);
            Destroy(balle, 0.3f);
        }
    }
}
