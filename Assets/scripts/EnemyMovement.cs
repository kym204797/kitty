using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f; // velocidad de movimiento del enemigo
    public float distance = 5f; // distancia máxima que recorre el enemigo antes de voltear
    public float chaseDistance = 5f; // distancia a la que el enemigo detecta al jugador y lo persigue

    private Rigidbody2D rb;
    private bool facingRight = true; // variable para saber si el enemigo está volteado hacia la derecha
    private Transform player; // referencia al transform del jugador
    private Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // obtenemos la referencia al Rigidbody2D del enemigo
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // obtenemos la referencia al transform del jugador
    }

    void Update()
    {
        // calculamos la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // si la distancia es menor o igual a la distancia de persecución, perseguimos al jugador
        if (distanceToPlayer <= chaseDistance)
        {
            // movemos al enemigo hacia el jugador
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * speed;

            // voltear al enemigo según la dirección en la que se mueve
            if (direction.x > 0 && !facingRight || direction.x < 0 && facingRight)
            {
                Flip();
            }
        }
        else
        {
            // movemos al enemigo en horizontal hasta alcanzar la distancia máxima
            if (facingRight)
            {
                rb.velocity = Vector2.right * speed;
            }
            else
            {
                rb.velocity = Vector2.left * speed;
            }

            // si hemos llegado a la distancia máxima, voltear al enemigo
            if (Mathf.Abs(transform.position.x - rb.position.x) >= distance)
            {
                Flip();
            }
        }

        // establecer el valor del parámetro Movement en el Animator
        animator.SetFloat("Movement", Mathf.Abs(rb.velocity.x));
    }

    // función para voltear al enemigo
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
