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

    internal bool isGuarding = false;
    private bool isRunning = false;
    private bool canMove = true; // kontrol pergerakan
    private float guardDuration = 2f; // Durasi guard dalam detik
    private float guardTimer = 0f; // Timer untuk menghitung waktu guard

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

        

        if (Input.GetKey(KeyCode.G) || Input.GetButton("XboxGuard"))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, collisionLayer);

            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("ground") && !isGuarding && canMove)
                {
                    // Memulai guard
                    StartGuard();
                }
            }
        }
        else if (Input.GetKeyUp(KeyCode.G) || Input.GetButton("XboxGuard"))
        {
            // Menghentikan guard
            StopGuard();
        }

    }

    void FixedUpdate()
    {
        if (canMove) // Cek apakah karakter dapat bergerak
        {
            DetectMovement();
            AnimatePlayerWalk();
            RotatePlayer();
            AnimatePlayerRun();
        }
        if (isGuarding)
        {
            guardTimer += Time.fixedDeltaTime;

            // Menghentikan guard setelah durasi tertentu
            if (guardTimer >= guardDuration)
            {
                StopGuard();
            }
        }
    }

    void AnimatePlayerRun()
    {
        float horizontalInput = Input.GetAxisRaw(AnimationTags.Axis.HORIZONTAL_AXIS) + Input.GetAxis("XboxHorizontal");
        float verticalInput = Input.GetAxisRaw(AnimationTags.Axis.VERTICAL_AXIS) + Input.GetAxis("XboxVertical");

        bool isRunningInput = Input.GetKey(KeyCode.LeftShift) || Input.GetButton("XboxRun");
        bool isRunning = isRunningInput && (horizontalInput != 0 || verticalInput != 0);

        player_Anim.Run(isRunning);
    }


    void DetectMovement()
    {
        float horizontalInput = Input.GetAxisRaw(AnimationTags.Axis.HORIZONTAL_AXIS) + Input.GetAxis("XboxHorizontal");
        float verticalInput = Input.GetAxisRaw(AnimationTags.Axis.VERTICAL_AXIS) + Input.GetAxis("XboxVertical");

        float speed = isRunning ? run_Speed : walk_Speed;

        // Determine if the player is running based on input
        bool isRunningInput = Input.GetKey(KeyCode.LeftShift) || Input.GetButton("XboxRun");
        isRunning = isRunningInput && (horizontalInput != 0 || verticalInput != 0);

        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;

        myBody.velocity = new Vector3(
            moveDirection.x * (-speed),
            myBody.velocity.y,
            moveDirection.z * (-z_Speed)
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
    void StartGuard()
    {
        isGuarding = true;
        player_Anim.Guard(true);
        guardTimer = 0f; // Mereset timer guard
    }

    void StopGuard()
    {
        isGuarding = false;
        player_Anim.Guard(false);
    }
    // Fungsi untuk menonaktifkan pergerakan karakter
    public void DisableMovement()
    {
        canMove = false;
        isRunning = false;
    }

    // Fungsi untuk mengaktifkan pergerakan karakter
    public void EnableMovement()
    {
        canMove = true;
    }
}
