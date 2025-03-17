using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murmobile : MonoBehaviour
{
    public GameObject movingWall; // Le mur mobile (autre GameObject)
    public float speed = 2f;      // Vitesse du mur
    public float moveDistance = 5f; // Distance totale de d�placement

    private Rigidbody wallRb;         // Rigidbody du mur
    private Vector3 wallStartPosition; // Position de d�part du mur
    private bool isActivated = false; // Indique si le mur doit bouger
    public int direction = 1;        // Pour d�terminer la direction du mouvement 1 pour droite, -1 pour gauche

    void Start()
    {
        
        if (movingWall == null)
        {
            Debug.LogError("Le mur mobile (movingWall) n'est pas assign� !"); // V�rifier que le mur est assign�
            return;
        }


        wallRb = movingWall.GetComponent<Rigidbody>(); // R�cup�rer le Rigidbody du mur
        if (wallRb == null)
        {
            Debug.LogError("Le GameObject 'movingWall' doit avoir un Rigidbody !");
            return;
        }

        
        wallStartPosition = movingWall.transform.position; // Enregistrer la position de d�part du mur
    }

    void FixedUpdate()
    {
        
        if (isActivated) // Si le mur est activ�, le faire bouger
        {
            Vector3 newPosition = wallRb.position + Vector3.right * direction * speed * Time.fixedDeltaTime;
            wallRb.MovePosition(newPosition);

            
            if (Vector3.Distance(wallStartPosition, wallRb.position) >= moveDistance) // Inverser la direction si la distance maximale est atteinte
            {
                direction *= -1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player")) // Activer le mur uniquement si c'est le joueur qui entre dans la zone
        {
            isActivated = true;
            Debug.Log("Le joueur a activ� le mur !");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player")) // Arr�ter le mur lorsque le joueur quitte la zone
        {
            isActivated = false;
            Debug.Log("Le joueur a d�sactiv� le mur !");
        }
    }
}