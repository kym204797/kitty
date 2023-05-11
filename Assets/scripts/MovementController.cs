using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 5f; // velocidad de movimiento del personaje
    public float jumpForce = 5f; // fuerza del salto del personaje
    public float attackCooldown = 0.6f; // tiempo de enfriamiento del ataque


    private Rigidbody2D rb;
    private bool isGrounded = true; // verifica si el personaje está en el suelo
    private Animator animator;
    private bool isAttacking = false; // verifica si el personaje está atacando
    private float attackTimer = 0f; // temporizador de enfriamiento del ataque


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

        if (horizontalMovement != 0)
        {
            animator.SetBool("isRunning", true); // establecemos el parámetro "isRunning" a true si el personaje se está moviendo
            transform.localScale = new Vector3(horizontalMovement < 0 ? -6 : 6, 6, 1); // voltear el personaje según el eje X
        }
        else
        {
            animator.SetBool("isRunning", false); // establecemos el parámetro "isRunning" a false si el personaje no se está moviendo
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Z) && !isAttacking)
        {
            animator.SetBool("isAttacking", true); // establecemos el parámetro "isAttacking" a true si la tecla "z" es presionada
            isAttacking = true; // establecemos el personaje como atacando
            attackTimer = attackCooldown; // reiniciamos el temporizador de enfriamiento del ataque
        }

        // si el personaje está atacando, comienza el temporizador de enfriamiento del ataque
        if (isAttacking)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0f)
            {
                animator.SetBool("isAttacking", false); // establecemos el parámetro "isAttacking" a false después de que se haya completado el ataque
                isAttacking = false; // establecemos el personaje como no atacando
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isGrounded", true); // establecemos el parámetro "isGrounded" a true si el personaje está en el suelo
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isGrounded", false); // establecemos el parámetro "isGrounded" a false si el personaje no está en el suelo
        }
    }
}