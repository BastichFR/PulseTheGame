using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Player {
    

    private int currentWeaponIndex = 0;
    
    public GameObject Gun;

    private GameObject firstWeapon;
    public GameObject AK47Prefab;
    public GameObject M4_8Prefab;

    private GameObject secondWeapon;
    public GameObject UZIPrefab;
    public GameObject M1911Prefab;

    private void Start() {
        Vector3 gunPosition = Gun.transform.position;
        switch (team) {
            case Team.Team1:
                firstWeapon = Instantiate(AK47Prefab, gunPosition, Quaternion.identity);
                secondWeapon = Instantiate(UZIPrefab, gunPosition, Quaternion.identity);
                break;
            case Team.Team2:
                firstWeapon = Instantiate(M4_8Prefab, gunPosition, Quaternion.identity);
                secondWeapon = Instantiate(M1911Prefab, gunPosition, Quaternion.identity);
                break;
            default:
                Debug.LogError("Invalid team selected");
                break;
        }
        firstWeapon.transform.SetParent(transform);
        secondWeapon.transform.SetParent(transform);

        DisplayCurrentWeapon();
    }
    
    void Update()
    {
        // Vérification si la touche 'a' est enfoncée
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (currentWeaponIndex != 0){
                currentWeaponIndex = 0;
                DisplayCurrentWeapon();
            }
        }

        // Vérification si la touche 'e' est enfoncée
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (currentWeaponIndex != 1){
                currentWeaponIndex = 1;
                DisplayCurrentWeapon();
            }
        }
    }

    void DisplayCurrentWeapon()
    {
        if(firstWeapon == null || secondWeapon == null) {
            Debug.LogError("Weapon objects are not set");
            return;
        }
        
        // Désactivation de toutes les armes dans la liste

        switch(currentWeaponIndex) {
            case 0 : 
                firstWeapon.SetActive(true);
                secondWeapon.SetActive(false);
                break;
            case 1 : 
                firstWeapon.SetActive(false);
                secondWeapon.SetActive(true);
                break;
        }
    }
}