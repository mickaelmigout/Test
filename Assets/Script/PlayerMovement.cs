using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;  // Vitesse de déplacement
    public float gravity = -9.81f; // Force de gravité
    public float jumpHeight = 1f; // Hauteur du saut

    private CharacterController controller;
    private Vector2 moveInput;  // Les directions (X, Y)
    private Vector3 velocity;  // Gestion des mouvements verticaux
    private bool isGrounded;

    private void Awake()
    {
        
        controller = GetComponent<CharacterController>(); // Récupère le Character Controller
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        
        moveInput = context.ReadValue<Vector2>();// Récupérer les entrées de direction (X = gauche/droite, Y = avant/arrière) 
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        
        if (isGrounded && context.performed) // Vérifie si le joueur est au sol avant d'autoriser un saut
        {
            
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Calcule la vitesse verticale pour le saut
        }
    }

    private void Update()
    {
        
        isGrounded = controller.isGrounded; // Vérifie si le joueur touche le sol et l'empêcher de sauté à l'infini

        
        if (isGrounded && velocity.y < 0) // Si le joueur est au sol et que la gravité agit, on réinitialise la vitesse verticale
        {
            velocity.y = -2f; // Valeur légèrement négative pour maintenir contact au sol
        }

        
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y; // Calcul du mouvement horizontal
        controller.Move(move * speed * Time.deltaTime);

        
        velocity.y += gravity * Time.deltaTime; // Applique la gravité

        
        controller.Move(velocity * Time.deltaTime); // Applique le mouvement vertical
    }
}
