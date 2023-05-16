using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaController : MonoBehaviour
{
    public GameObject panelPausa;
    public GameObject panelOptions;
    public GameObject mainPanel;
    public GameObject inicio;
    public GameObject dialogo1;
    public GameObject dialogo2;
    public GameObject dialogo3;
    public GameObject dialogo4;
    public GameObject dialogo5;

    void Update()
    {
        if (panelPausa.activeSelf == true || panelOptions.activeSelf == true || mainPanel.activeSelf == true || dialogo1.activeSelf == true
       || dialogo2.activeSelf == true || dialogo3.activeSelf == true || dialogo4.activeSelf == true || dialogo5.activeSelf == true || inicio.activeSelf == true) // Validar que el panel de pausa esta activado
        {
            Time.timeScale = 0f; // Pausar el tiempo de juego
        }
        else
        {
            Time.timeScale = 1f; // Reanudar el tiempo del juego
        }
    }
}
