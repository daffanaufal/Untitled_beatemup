using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    private Characteranimation player_Anim;
    private Rigidbody myBody;

    public float walk_Speed = 3f;
    public float z_Speed = 1.5f;
    private float rotation_speed = 15f;

    private float rotation_y = -90f;

    //health (UBAH AJA YAA, INI BUAT SEMENTARA AJA)
    public int maxHP = 10;
    int currentHP;

    //health (UBAH AJA YAA, INI BUAT SEMENTARA AJA) MAAFF
    public void Start()
    {
        currentHP = maxHP;
    }

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        player_Anim = GetComponentInChildren<Characteranimation>();
    }

    void Update()
    {
        
        RotatePlayer();
        AnimatePlayerWalk();

        // Menambahkan logika untuk serangan jika diperlukan
        if (Input.GetKeyDown(KeyCode.P)) // Tombol 'P' untuk punch
        {
            // Panggil metode untuk melakukan pukulan
            player_Anim.Punch();
        }
        else if (Input.GetKeyDown(KeyCode.K)) // Tombol 'K' untuk kick
        {
            // Panggil metode untuk melakukan tendangan
            player_Anim.Kick();
        }
        if (Input.GetKeyDown(KeyCode.Space))
            {
                // Panggil metode untuk melakukan lompatan
                player_Anim.Jump();
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

        myBody.velocity = new Vector3(
            moveDirection.x * (-walk_Speed),
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

    //health (UBAH AJA YAA, INI BUAT SEMENTARA AJA)
    public void TakeDamage(int damageAmount)
    {
        currentHP -= damageAmount;
        Debug.Log(currentHP + "/" + maxHP);
    }
}
