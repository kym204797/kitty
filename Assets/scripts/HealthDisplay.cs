using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth; // referencia al componente HealthController
    private TextMeshProUGUI healthText; // referencia al objeto de texto que mostrará la cantidad de HP

    private void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>(); // obtiene la referencia al objeto de texto
    }

    private void Update()
    {
        // Actualiza el texto para mostrar la cantidad actual y máxima de HP
        healthText.text = "HP: " + playerHealth.currentHealth.ToString() + "/" + playerHealth.maxHealth.ToString();
    }
}
