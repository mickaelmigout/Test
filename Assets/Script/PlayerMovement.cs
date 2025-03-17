using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;  // Vitesse de d�placement
    public float gravity = -9.81f; // Force de gravit�
    public float jumpHeight = 1f; // Hauteur du saut

    private CharacterController controller;
    private Vector2 moveInput;  // Les directions (X, Y)
    private Vector3 velocity;  // Gestion des mouvements verticaux
    private bool isGrounded;

    private void Awake()
    {
        
        controller = GetComponent<CharacterController>(); // R�cup�re le Character Controller
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        
        moveInput = context.ReadValue<Vector2>();// R�cup�rer les entr�es de direction (X = gauche/droite, Y = avant/arri�re) 
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        
        if (isGrounded && context.performed) // V�rifie si le joueur est au sol avant d'autoriser un saut
        {
            
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Calcule la vitesse verticale pour le saut
        }
    }

    private void Update()
    {
        
        isGrounded = controller.isGrounded; // V�rifie si le joueur touche le sol et l'emp�cher de saut� � l'infini

        
        if (isGrounded && velocity.y < 0) // Si le joueur est au sol et que la gravit� agit, on r�initialise la vitesse verticale
        {
            velocity.y = -2f; // Valeur l�g�rement n�gative pour maintenir contact au sol
        }

        
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y; // Calcul du mouvement horizontal
        controller.Move(move * speed * Time.deltaTime);

        
        velocity.y += gravity * Time.deltaTime; // Applique la gravit�

        
        controller.Move(velocity * Time.deltaTime); // Applique le mouvement vertical
    }
}
