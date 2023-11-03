using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    private Characteranimation player_Anim;
    private Rigidbody myBody;

    public float walk_Speed = 3f;
    public float run_Speed = 6f;
    public float z_Speed = 1.5f;
    private float rotation_speed = 15f;
    private float rotation_y = -90f;
    public float lompatan;

    private bool isGuarding = false;
    private bool isRunning = false;
    private bool canMove = true; // kontrol pergerakan

    public LayerMask collisionLayer;
    public float radius = 1f;

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        player_Anim = GetComponentInChildren<Characteranimation>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButton("XboxJump"))
        {
            if (canMove)
            {
                Jump();
            }
        }

        if (canMove) // Cek apakah karakter dapat bergerak
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButton("XboxRun"))
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, collisionLayer);

                foreach (Collider col in hitColliders)
                {
                    if (col.CompareTag("ground"))
                    {
                        isRunning = true;
                        player_Anim.Run(true);
                    }
                }
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetButton("XboxRun"))
            {
                isRunning = false;
                player_Anim.Run(false);
            }
        }


        if (Input.GetKey(KeyCode.G) || Input.GetButton("XboxGuard"))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, collisionLayer);

            foreach (Collider col in hitColliders)
                if (col.CompareTag("ground") && !isGuarding && canMove) // Hanya menjalankan Guard jika karakter dapat bergerak
            {
                isGuarding = true;
                player_Anim.Guard(true); // Aktifkan animasi Guard
            }
        }
        else if (Input.GetKeyUp(KeyCode.G) || Input.GetButton("XboxGuard"))
        {
            isGuarding = false;
            player_Anim.Guard(false); // Nonaktifkan animasi Guard
        }
    }

    void FixedUpdate()
    {
        if (canMove) // Cek apakah karakter dapat bergerak
        {
            DetectMovement();
            AnimatePlayerWalk();
            RotatePlayer();
        }
    }

    void DetectMovement()
    {
        float horizontalInput = Input.GetAxisRaw(AnimationTags.Axis.HORIZONTAL_AXIS) + Input.GetAxis("XboxHorizontal");
        float verticalInput = Input.GetAxisRaw(AnimationTags.Axis.VERTICAL_AXIS) + Input.GetAxis("XboxVertical");

        // Koreksi arah pergerakan sesuai keinginan
        horizontalInput = -horizontalInput;
        verticalInput = -verticalInput;

        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;

        float speed = isRunning ? run_Speed : walk_Speed;

        myBody.velocity = new Vector3(
            moveDirection.x * speed, //koreksi arah pergerakan
            myBody.velocity.y,
            moveDirection.z * z_Speed //koreksi arah pergerakan
        );
    }

    void RotatePlayer()
    {
        float horizontalInput = Input.GetAxisRaw(AnimationTags.Axis.HORIZONTAL_AXIS) + Input.GetAxis("XboxHorizontal");

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
        float horizontalInput = Input.GetAxisRaw(AnimationTags.Axis.HORIZONTAL_AXIS) + Input.GetAxis("XboxHorizontal");
        float verticalInput = Input.GetAxisRaw(AnimationTags.Axis.VERTICAL_AXIS) + Input.GetAxis("XboxVertical");

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

    // Fungsi untuk menonaktifkan pergerakan karakter
    public void DisableMovement()
    {
        canMove = false;
    }

    // Fungsi untuk mengaktifkan pergerakan karakter
    public void EnableMovement()
    {
        canMove = true;
    }
}
