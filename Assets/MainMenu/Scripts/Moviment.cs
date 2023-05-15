using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour
{
    public float speed = 2f; // Velocidad de movimiento del cubo

    void Update()
    {
        // Mover el cubo hacia adelante constantemente
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

