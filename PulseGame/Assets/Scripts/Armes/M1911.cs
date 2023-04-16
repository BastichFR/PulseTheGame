using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1911 : Arme
{
    // Start is called before the first frame update
    protected override void Start()
    {
        chargeurCapacity = 8;
        nombreChargeurs = 7;
        degats = 55;
        fireRate = 0.01f;
        reloadTime = 1f;

        semiAutomatic = false;

        base.Start();  // appelle la méthode Start() de la classe parent
    }
}
