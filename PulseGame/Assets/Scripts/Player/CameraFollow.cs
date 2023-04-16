using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Le transform du joueur à suivre
    public float height = 10f; // La hauteur à laquelle la caméra doit être placée au-dessus du joueur
    public float smoothSpeed = 0.1f; // La vitesse à laquelle la caméra suit le joueur

    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0f, height, 0f); // Initialise l'offset de la caméra
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // Calcule la position désirée de la caméra
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Calcule la position lissée de la caméra en utilisant Lerp
        transform.position = smoothedPosition; // Applique la position lissée à la caméra
    }
}
