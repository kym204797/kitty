using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 5f; // velocidad de movimiento del personaje
    public float jumpForce = 5f; // fuerza del salto del personaje

    private Rigidbody2D rb;
    private bool isGrounded = true; // verifica si el personaje est� en el suelo
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // obtenemos la referencia al Rigidbody2D del personaje
        animator = GetComponent<Animator>(); // obtenemos la referencia al Animator del personaje
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal"); // obtenemos la entrada horizontal (izquierda/derecha)

        // actualizamos la posici�n del transform del personaje
        transform.position += Vector3.right * horizontalMovement * speed * Time.deltaTime;

        if (horizontalMovement != 0)
        {
            animator.SetBool("isRunning", true); // establecemos el par�metro "isRunning" a true si el personaje se est� moviendo
            transform.localScale = new Vector3(horizontalMovement < 0 ? -6 : 6, 6, 1); // voltear el personaje seg�n el eje X
        }
        else
        {
            animator.SetBool("isRunning", false); // establecemos el par�metro "isRunning" a false si el personaje no se est� moviendo
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool("isAttacking", true); // establecemos el par�metro "isAttacking" a true si la tecla "z" es presionada
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isGrounded", true); // establecemos el par�metro "isGrounded" a true si el personaje est� en el suelo
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isGrounded", false); // establecemos el par�metro "isGrounded" a false si el personaje no est� en el suelo
        }
    }
}


