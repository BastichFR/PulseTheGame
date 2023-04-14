using UnityEngine;
using System.Collections;

public class M4_8 : Arme
{

    protected override void Start()
    {
        chargeurCapacity = 30;
        nombreChargeurs = 7;
        degats = 44;
        fireRate = 0.08f;
        reloadTime = 1f;

        semiAutomatic = true;

        base.Start();  // appelle la méthode Start() de la classe parent
    }
}
