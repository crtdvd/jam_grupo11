using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float damage = 15f;
    public float health = 100f;
    public float energy = 100f;

    private Animator animator;
    public GameObject arma;
    private Rigidbody rb;
    public float speed = 15f;
    public float turnSpeed = 360f;
    public Vector3 input;
    bool bIsAttacking = false;
    float AttackTimer = 0f;

    [Header("UI")]

    public Image healthBar;
    public Image energyBar;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        DesactivarColliderArma();
    }

    private void Update()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        Look();
        updateIU();

        //wait time for restore energy
        AttackTimer -= Time.deltaTime;
        if (AttackTimer <= 0f && energy < 100f)
        {
            energy += 25;
            AttackTimer = 1.5f;
        }
    }

    void updateIU()
    {
        if(healthBar)
        {
            float smoothHealth = Mathf.Lerp(healthBar.fillAmount, health / 100f, 0.5f);
            healthBar.fillAmount = smoothHealth;
        }

        if(energyBar)
        {
            float smoothenergy = Mathf.Lerp(energyBar.fillAmount, energy / 100f, 0.2f);
            energyBar.fillAmount = smoothenergy;
        }
    }

    private void FixedUpdate()
    {
        if (health > 0f)
        {
            Move();

            if (Input.GetKeyDown(KeyCode.Space) && energy > 0f)
            {
                Attack();
            }
        }
    }

    void Move()
    {
        //rb.MovePosition(transform.position + (transform.forward * input.normalized.magnitude) * speed * Time.deltaTime);
        Vector3 playerVelocity = (transform.forward * input.normalized.magnitude) * speed;
        animator.SetFloat("vel", playerVelocity.magnitude);
        playerVelocity.y = rb.velocity.y;
        if (bIsAttacking)
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }
        else
        {
            rb.velocity = playerVelocity;
        }
    }

    void Look()
    {
        if (input != Vector3.zero)
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

            var skededInput = matrix.MultiplyPoint3x4(input);

            var relative = (transform.position + skededInput) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        animator.SetInteger("AttackIndex", Random.Range(0, 2));
        animator.SetTrigger("Attack");
        energy -= 10f;
        AttackTimer = 5f;
        bIsAttacking = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyAttack")
        {
            TakeDamage(5f);
        }
    }

    public void TakeDamage(float inDamage)
    {
        health -= inDamage;

        if (health <= 0)
        {
            // Instantiate(EnemyPrefab, GetRandonWaypoint(), Quaternion.identity);
            Invoke(nameof(die), 0.5f);
        }
    }

    void die()
    {

    }

    public void ActivarColliderArma()
    {
        arma.SetActive(true);
    }

    public void DesactivarColliderArma()
    {
        bIsAttacking = false;
        arma.SetActive(false);
    }
}
