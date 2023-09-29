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

    void Awake()
    {
            player_anim = GetComponentInChildren<Characteranimation>();   
    }
    void Start()
    {
        current_Combo_Timer = default_Combo_Timer;
        current_Combo_State = ComboState.None;
    }

    // Update is called once per frame
    void Update()
    {
        ComboAttacks();
        ResetComboState();
    }
    void ComboAttacks()
        //kick3 belum dibuat yaa sementara 2 dulu
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (current_Combo_State == ComboState.Punch_3 ||
            current_Combo_State == ComboState.Kick ||
            current_Combo_State == ComboState.Kick_2 ||
             current_Combo_State == ComboState.Kick_3)
            {
                ResetComboState();
            }
            else
            {
                current_Combo_State++;
                activateTimerToReset = true;
                current_Combo_Timer = default_Combo_Timer;

                if (current_Combo_State == ComboState.Punch)
                {
                    player_anim.Punch();
                }
                else if (current_Combo_State == ComboState.Punch_2)
                {
                    player_anim.Punch_2();
                }
                else if (current_Combo_State == ComboState.Punch_3)
                {
                    player_anim.Punch_3();
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            if (current_Combo_State == ComboState.Kick_3 ||
                current_Combo_State == ComboState.Punch_3)
                return;

            if(current_Combo_State == ComboState.None||
                current_Combo_State == ComboState.Punch||
                current_Combo_State == ComboState.Punch_2)
            {
                current_Combo_State = ComboState.Kick;

            }else if(current_Combo_State == ComboState.Kick)
            {
                current_Combo_State++;
            }
            activateTimerToReset=true;
            current_Combo_Timer = default_Combo_Timer;

            if(current_Combo_State == ComboState.Kick)
            {
                player_anim.Kick();
            }
            if (current_Combo_State == ComboState.Kick_2)
            {
                player_anim.Kick_2();
            }
            if (current_Combo_State == ComboState.Kick_3)
            {
                player_anim.Kick_3();
            }
        }
    }

    void ResetComboState()
    {
        if (activateTimerToReset)
        {
            current_Combo_Timer -= Time.deltaTime;

            if(current_Combo_Timer <= 0f)
            {
                current_Combo_State = ComboState.None;

                activateTimerToReset=false;
                current_Combo_Timer = default_Combo_Timer;
            }
        }
    }
}
