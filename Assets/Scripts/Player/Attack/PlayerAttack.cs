using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState
{
    None,
    Punch,
    Punch_2,
    Punch_3,
    Kick,
    Kick_2,
    Kick_3,
    StrongPunch,
    SpecialKick
}

public class PlayerAttack : MonoBehaviour
{
    private Characteranimation player_anim;
    private bool activateTimerToReset;
    private float default_Combo_Timer = 0.4f;
    private float current_Combo_Timer;
    private ComboState current_Combo_State;

    public LayerMask collisionLayer;
    public float radius = 0.1f;

    //public bool canMove = true;

    void Awake()
    {
        player_anim = GetComponentInChildren<Characteranimation>();
    }

    void Start()
    {
        current_Combo_Timer = default_Combo_Timer;
        current_Combo_State = ComboState.None;
    }

    void Update()
    {
        ComboAttacks();
        ResetComboState();
        specialattackpunch();
        specialattackkick();
    }

    void ComboAttacks()
    {
        if ((Input.GetKeyDown(KeyCode.J) && Input.GetKey(KeyCode.LeftShift)) || Input.GetButton("XboxStrongPunch"))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, collisionLayer);

            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("ground"))
                {
                    if (current_Combo_State != ComboState.StrongPunch)
                    {
                        current_Combo_State = ComboState.StrongPunch;
                        activateTimerToReset = true;
                        current_Combo_Timer = default_Combo_Timer;
                        player_anim.Punch(); // Implementasi StrongPunch sesuai kebutuhan Anda
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.J) || Input.GetButton("XboxPunch"))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, collisionLayer);

            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("ground"))
                {
                    if (current_Combo_State == ComboState.Punch_3 || current_Combo_State == ComboState.Kick_3)
                    {
                        ResetComboState();
                    }
                    else if (current_Combo_State == ComboState.Punch_2)
                    {
                        current_Combo_State = ComboState.Punch_3;
                        activateTimerToReset = true;
                        current_Combo_Timer = default_Combo_Timer;
                        player_anim.Punch_3();
                    }
                    else if (current_Combo_State == ComboState.Punch)
                    {
                        current_Combo_State = ComboState.Punch_2;
                        activateTimerToReset = true;
                        current_Combo_Timer = default_Combo_Timer;
                        player_anim.Punch_2();
                    }
                    else
                    {
                        current_Combo_State = ComboState.Punch;
                        activateTimerToReset = true;
                        current_Combo_Timer = default_Combo_Timer;
                        player_anim.Punch();
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.K) || Input.GetButton("XboxKick"))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, collisionLayer);

            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("ground"))
                {
                    if (current_Combo_State == ComboState.Punch_3 || current_Combo_State == ComboState.Kick_3)
                    {
                        ResetComboState();
                    }
                    else if (current_Combo_State == ComboState.Kick_2)
                    {
                        current_Combo_State = ComboState.Kick_3;
                        activateTimerToReset = true;
                        current_Combo_Timer = default_Combo_Timer;
                        player_anim.Kick_3();
                    }
                    else if (current_Combo_State == ComboState.Kick)
                    {
                        current_Combo_State = ComboState.Kick_2;
                        activateTimerToReset = true;
                        current_Combo_Timer = default_Combo_Timer;
                        player_anim.Kick_2();
                    }
                    else
                    {
                        current_Combo_State = ComboState.Kick;
                        activateTimerToReset = true;
                        current_Combo_Timer = default_Combo_Timer;
                        player_anim.Kick();
                    }
                }
            }
        }
    }

    void ResetComboState()
    {
        if (activateTimerToReset)
        {
            current_Combo_Timer -= Time.deltaTime;

            if (current_Combo_Timer <= 0f)
            {
                current_Combo_State = ComboState.None;
                activateTimerToReset = false;
                current_Combo_Timer = default_Combo_Timer;
            }
        }
    }

    void specialattackpunch()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            player_anim.Strongpunch();
        }
    }


    void specialattackkick()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            player_anim.Specialkick();
        }
    }

    //public void DisableMovement()
    //{
    //    canMove = false;
    // }

    // Fungsi untuk mengaktifkan pergerakan karakter
    //public void EnableMovement()
    //{
    //    canMove = true;
    //}
}
