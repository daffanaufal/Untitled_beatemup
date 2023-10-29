using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    private Characteranimation player_Anim;
    private Rigidbody myBody;

    public float walk_Speed = 3f;
    public float run_Speed = 6f; // Speed for running
    public float z_Speed = 1.5f;
    private float rotation_speed = 15f;
    private float rotation_y = -90f;
    public float lompatan;

    private bool isGuarding = false;
    private bool isRunning = false; // Track whether the player is running

    public LayerMask collisionLayer;
    public float radius = 1f;

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        player_Anim = GetComponentInChildren<Characteranimation>();
    }

    void Update()
    {
        RotatePlayer();
        AnimatePlayerWalk();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, collisionLayer);

            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("ground"))
                {
                   isRunning = true;
                }
            }
            
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }

        // Menggunakan Input.GetKeyDown untuk hanya mengatur isGuarding saat tombol ditekan
        if (Input.GetKeyDown(KeyCode.G))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, collisionLayer);

            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("ground"))
                {
                    player_Anim.Guard(); // Memanggil metode Guard dengan nilai isGuarding saat tombol ditekan.
                }
            }
            
        }
    }

    void FixedUpdate()
    {
        DetectMovement();
    }

    void DetectMovement()
    {
        float horizontalInput = Input.GetAxisRaw(AnimationTags.Axis.HORIZONTAL_AXIS);
        float verticalInput = Input.GetAxisRaw(AnimationTags.Axis.VERTICAL_AXIS);

        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;

        float speed = isRunning ? run_Speed : walk_Speed; // Use run_Speed if running, else use walk_Speed

        myBody.velocity = new Vector3(
            moveDirection.x * (-speed),
            myBody.velocity.y,
            moveDirection.z * (-z_Speed)
        );
    }

    void RotatePlayer()
    {
        float horizontalInput = Input.GetAxisRaw(AnimationTags.Axis.HORIZONTAL_AXIS);

        if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0f, rotation_y, 0f);
        }
        else if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotation_y), 0f);
        }
    }

    void AnimatePlayerWalk()
    {
        float horizontalInput = Input.GetAxisRaw(AnimationTags.Axis.HORIZONTAL_AXIS);
        float verticalInput = Input.GetAxisRaw(AnimationTags.Axis.VERTICAL_AXIS);

        bool isWalking = horizontalInput != 0 || verticalInput != 0;

        player_Anim.Walk(isWalking);
    }

    void Jump()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        foreach (Collider col in hitColliders)
        {
            if (col.CompareTag("ground"))
            {
                player_Anim.Jump();
                myBody.AddForce(Vector3.up * lompatan);   
            }
        }
        
    }
}

