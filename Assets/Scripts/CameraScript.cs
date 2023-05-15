using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    
    void Update()
    {
        if(target)
        {
            transform.position = target.position;
        }
    }
}
