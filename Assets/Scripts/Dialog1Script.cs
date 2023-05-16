using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog1Script : MonoBehaviour
{
    public GameObject dialogo1;
    BoxCollider boxCol;
    // Start is called before the first frame update
    void Start()
    {
        boxCol = GetComponent<BoxCollider>();
    }
    public void setTrigger()
    {
        boxCol.isTrigger = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        dialogo1.SetActive(true);
    }
}
