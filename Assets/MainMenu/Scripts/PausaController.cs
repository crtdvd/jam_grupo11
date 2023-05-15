using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaController : MonoBehaviour
{
    public GameObject panelPausa;
    public GameObject panelOptions;

    void Update()
    {
        if (panelPausa.activeSelf == true || panelOptions.activeSelf == true) // Validar que el panel de pausa esta activado
        {
            Time.timeScale = 0f; // Pausar el tiempo de juego
        }
        else
        {
            Time.timeScale = 1f; // Reanudar el tiempo del juego
        }
    }
}
