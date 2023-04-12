using UnityEngine;

public class Arme : MonoBehaviour
{
    public GameObject ballePrefab;
    public Transform pointDeTir;
    public float forceDeTir = 500f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Tirer();
        }
    }

    void Tirer()
    {
        GameObject balle = Instantiate(ballePrefab, pointDeTir.position, pointDeTir.rotation);
        Rigidbody rb = balle.GetComponent<Rigidbody>();
        rb.AddForce(pointDeTir.forward * forceDeTir);
    }
}
