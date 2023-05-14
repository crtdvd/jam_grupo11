using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public GameObject arma;
    private Rigidbody rb;
    public float speed = 15f;
    public float turnSpeed = 360f;
    public Vector3 input;
    bool bIsAttacking = false;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetInteger("AttackIndex", Random.Range(0, 2));
            animator.SetTrigger("Attack");

            bIsAttacking = true;
        }
    }

    private void FixedUpdate()
    {
        Move();
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
