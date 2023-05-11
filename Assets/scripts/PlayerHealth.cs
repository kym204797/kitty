using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // cantidad m�xima de puntos de vida
    public int currentHealth; // cantidad actual de puntos de vida

    private bool isInvincible = false; // si el jugador es invencible o no
    public float invincibilityTime = 2f; // tiempo en segundos de invencibilidad despu�s de recibir da�o

    void Start()
    {
        currentHealth = maxHealth; // establecemos la cantidad actual de puntos de vida al m�ximo al inicio
    }

    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible) // si el jugador no es invencible
        {
            currentHealth -= damage; // reducimos la cantidad actual de puntos de vida seg�n el da�o recibido
            isInvincible = true; // hacemos al jugador invencible temporalmente
            Invoke("ResetInvincibility", invincibilityTime); // establecemos un temporizador para hacer al jugador vulnerable de nuevo

            if (currentHealth <= 0) // si el jugador se queda sin puntos de vida
            {
                Die(); // llamamos a la funci�n Die
            }
        }
    }

    void Die()
    {
        gameObject.SetActive(false); // desactivamos el objeto del jugador
        Debug.Log("You died!"); // mostramos un mensaje en la consola
    }

    void ResetInvincibility()
    {
        isInvincible = false; // hacemos al jugador vulnerable de nuevo
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // si chocamos con un objeto con la etiqueta "Enemy"
        {
            TakeDamage(10); // llamamos a la funci�n TakeDamage con un valor de da�o de 10
        }
    }
}

