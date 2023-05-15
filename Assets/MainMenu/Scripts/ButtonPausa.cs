using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject panelCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelCanvas.SetActive(true);
        }
    }
}
