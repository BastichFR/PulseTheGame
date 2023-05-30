using UnityEngine;
using System.Collections;

public class UZI : Arme
{
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
}
