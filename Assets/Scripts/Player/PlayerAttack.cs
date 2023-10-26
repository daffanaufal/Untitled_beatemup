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
    Kick_3
}

public class PlayerAttack : MonoBehaviour
{
    private Characteranimation player_anim;

    private bool activateTimerToReset;

    private float default_Combo_Timer = 0.4f;
    private float current_Combo_Timer;

    private ComboState current_Combo_State;

    private bool isUsingController = false; // Menyimpan apakah pengguna menggunakan controller

    void Awake()
    {
        player_anim = GetComponentInChildren<Characteranimation>();
    }

    void Start()
    {
        current_Combo_Timer = default_Combo_Timer;
        current_Combo_State = ComboState.None;

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
        ComboAttacks();
        ResetComboState();
    }

    void ComboAttacks()
    {
        if (isUsingController)
        {
            if (Input.GetButtonDown("XButton"))
            {
                // Implementasikan combo attacks untuk controller di sini
            }
            else if (Input.GetButtonDown("BButton"))
            {
                // Implementasikan combo attacks untuk controller di sini
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                // Implementasikan combo attacks untuk keyboard dan mouse di sini
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                // Implementasikan combo attacks untuk keyboard dan mouse di sini
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
}
