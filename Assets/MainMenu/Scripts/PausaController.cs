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
    public GameObject salida;

    void Update()
    {
        if (panelPausa.activeInHierarchy || panelOptions.activeInHierarchy || mainPanel.activeInHierarchy 
        || dialogo1.activeInHierarchy || dialogo2.activeInHierarchy || dialogo3.activeInHierarchy 
        || dialogo4.activeInHierarchy || dialogo5.activeInHierarchy || inicio.activeInHierarchy || salida.activeInHierarchy) // Validar que el panel de pausa esta activado
        {
            Time.timeScale = 0f; // Pausar el tiempo de juego
        }
        else
        {
            Time.timeScale = 1f; // Reanudar el tiempo del juego
        }
    }
}
