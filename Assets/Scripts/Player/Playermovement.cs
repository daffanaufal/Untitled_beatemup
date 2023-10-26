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

    private bool isGuarding = false;
    private bool isRunning = false;

    private bool isUsingController = false; // Menyimpan apakah pengguna menggunakan controller

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        player_Anim = GetComponentInChildren<Characteranimation>();
    }

    void Start()
    {
        // Mengecek apakah ada controller terhubung
        string[] joystickNames = Input.GetJoystickNames();
        foreach (string joystickName in joystickNames)
        {
            if (!string.IsNullOrEmpty(joystickName))
            {
                isUsingController = true;
                break;
            }
        }
    }

    void Update()
    {
        RotatePlayer();
        AnimatePlayerWalk();

        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (isUsingController)
        {
            // Input untuk Xbox Controller
            horizontalInput = Input.GetAxis("XboxHorizontal");
            verticalInput = Input.GetAxis("XboxVertical");
        }
        else
        {
            // Input untuk keyboard controller
            horizontalInput = Input.GetAxis(AnimationTags.Axis.HORIZONTAL_AXIS);
            verticalInput = Input.GetAxis(AnimationTags.Axis.VERTICAL_AXIS);
        }

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        movement = Vector3.ClampMagnitude(movement, 1.0f);

        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotation_speed * Time.deltaTime);
        }

        transform.Translate(movement * (isRunning ? run_Speed : walk_Speed) * Time.deltaTime, Space.World);

        if (Input.GetButtonDown("Jump") || (isUsingController && Input.GetButtonDown("XboxJump"))) // Tombol "A" pada Xbox Controller
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }

        // Menggunakan Input.GetKeyDown untuk hanya mengatur isGuarding saat tombol ditekan
        if (Input.GetKeyDown(KeyCode.L))
        {
            player_Anim.Guard();
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

        float speed = isRunning ? run_Speed : walk_Speed;

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
        player_Anim.Jump();
    }
}
