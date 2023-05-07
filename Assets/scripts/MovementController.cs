using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 5f; // velocidad de movimiento del personaje
    public float jumpForce = 5f; // fuerza del salto del personaje

    private Rigidbody2D rb;
    private Animator animator; // referencia al componente Animator
    private bool isGrounded = true; // verifica si el personaje está en el suelo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // obtenemos la referencia al Rigidbody2D del personaje
        animator = GetComponent<Animator>(); // obtenemos la referencia al Animator del personaje
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal"); // obtenemos la entrada horizontal (izquierda/derecha)

        // actualizamos la posición del transform del personaje
        transform.position += Vector3.right * horizontalMovement * speed * Time.deltaTime;

        // establecer el valor del parámetro isRunning en función de si el personaje está moviéndose o no
        animator.SetBool("isRunning", horizontalMovement != 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("isGrounded", false); // establecer el valor del parámetro isGrounded en false
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isGrounded", true); // establecer el valor del parámetro isGrounded en true
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("isGrounded", false); // establecer el valor del parámetro isGrounded en false
        }
    }
}
