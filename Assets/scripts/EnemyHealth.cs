using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // cantidad m�xima de vida
    public int currentHealth; // vida actual

    private void Start()
    {
        currentHealth = maxHealth; // inicializar la vida actual como la cantidad m�xima de vida
    }

    // funci�n para recibir da�o
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // restar el da�o recibido a la vida actual

        if (currentHealth <= 0)
        {
            Die(); // si la vida llega a 0, llamar a la funci�n Die
        }
    }

    // funci�n para morir
    void Die()
    {
        gameObject.SetActive(false); // desactivar el objeto
    }

    // funci�n para detectar colisiones
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log(collision.transform.name);
        if (collision.gameObject.CompareTag("Hit"))
        {
            TakeDamage(10); // restar 10 de vida al enemigo si colisiona con un objeto con tag "Hit"
        }
        else if(collision.transform.childCount > 0)
        {
            if (collision.transform.GetChild(0).gameObject.CompareTag("Hit") && collision.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                Debug.Log("Hit");
                TakeDamage(10); // restar 10 de vida al enemigo si colisiona con un objeto con tag "Hit"
            }
        }
    }
}
