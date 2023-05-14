using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BasicEnemyScript : MonoBehaviour
{
    public GameObject DamageArea;
    private NavMeshAgent agent;
    private Transform player;
    private Animator animator;

    public LayerMask playerLayer;

    public float health = 30f;
    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked = false;

    //states
    public float attackRange;
    public bool bIsPlayerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //Check for sight and attack range
        bIsPlayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if (bIsPlayerInAttackRange)
        {
            AttackPlayer();
        }
        else
        {
            ChasePlayer();
        }

        animator.SetFloat("vel", agent.velocity.magnitude);
    }

    private void ChasePlayer()
    {
        Debug.Log("chasing");
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        Debug.Log("attacking");
        //the sure enemy doesn't move
        agent.SetDestination(transform.position);

        Vector3 playerLookAt = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(playerLookAt);

        if (!alreadyAttacked)
        {
            //Attack code 
            animator.SetTrigger("attack");
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(float inDamage)
    {
        health -= inDamage;

        if (health <= 0)
        {
            // Instantiate(EnemyPrefab, GetRandonWaypoint(), Quaternion.identity);
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerAttack")
        {
            TakeDamage(player.GetComponent<PlayerController>().damage);
        }
    }

    public void ActivateDamageArea()
    {
        DamageArea.SetActive(true);
    }

    public void DeactivateDamageArea()
    {
        DamageArea.SetActive(false);
    }
}
