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

    private AttackUniversal playerAttackUniversal;
    public DValue DamageValue;                      //Call Class DValue Name

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
                        playerAttackUniversal.SetDamage(DamageValue.StrongPunch1Value); //EDIT AJA YAKK ^^
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
                        playerAttackUniversal.SetDamage(DamageValue.punch3Value); //EDIT AJA YAKK ^^
                    }
                    else if (current_Combo_State == ComboState.Punch)
                    {
                        current_Combo_State = ComboState.Punch_2;
                        activateTimerToReset = true;
                        current_Combo_Timer = default_Combo_Timer;
                        player_anim.Punch_2();
                        playerAttackUniversal.SetDamage(DamageValue.punch2Value); //EDIT AJA YAKK ^^
                    }
                    else
                    {
                        current_Combo_State = ComboState.Punch;
                        activateTimerToReset = true;
                        current_Combo_Timer = default_Combo_Timer;
                        player_anim.Punch();
                        playerAttackUniversal.SetDamage(DamageValue.punch1Value); //EDIT AJA YAKK ^^
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
                        playerAttackUniversal.SetDamage(DamageValue.kick3Value);  //EDIT AJA YAKK ^^
                    }
                    else if (current_Combo_State == ComboState.Kick)
                    {
                        current_Combo_State = ComboState.Kick_2;
                        activateTimerToReset = true;
                        current_Combo_Timer = default_Combo_Timer;
                        player_anim.Kick_2();
                        playerAttackUniversal.SetDamage(DamageValue.kick2Value);  //EDIT AJA YAKK ^^
                    }
                    else
                    {
                        current_Combo_State = ComboState.Kick;
                        activateTimerToReset = true;
                        current_Combo_Timer = default_Combo_Timer;
                        player_anim.Kick();
                        playerAttackUniversal.SetDamage(DamageValue.kick1Value); //EDIT AJA YAKK ^^
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
            playerAttackUniversal.SetDamage(DamageValue.SpPunchValue); //EDIT AJA YAKK ^^
        }
    }


    void specialattackkick()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            player_anim.Specialkick();
            playerAttackUniversal.SetDamage(DamageValue.SpKickValue); //EDIT AJA YAKK ^^ 
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

    [System.Serializable]               //different damage value for each attack type 
    public class DValue
    {
        public int StrongPunch1Value;   //Strong Punch attack value 
        public int punch1Value;         //Punch attack value 
        public int punch2Value;
        public int punch3Value;
        public int kick1Value;          //Kick attack value
        public int kick2Value;
        public int kick3Value;
        public int SpPunchValue;        //Special Attack value
        public int SpKickValue;
    }
}
