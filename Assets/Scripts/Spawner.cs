using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyNumber = 7;
    public Transform[] spawnPositions;
     bool spawning = false;
    BoxCollider boxCollider;
    float timer = 0f;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(spawning && timer <= 0f && enemyNumber > 0)
        {
            timer = 3f;
            enemyNumber--;
            int index = Random.Range(0, spawnPositions.Length);
            Instantiate(enemyPrefab, spawnPositions[index]);
        }
    }
    public void setTrigger()
    {
        boxCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spawning = true;
        }
    }
}
