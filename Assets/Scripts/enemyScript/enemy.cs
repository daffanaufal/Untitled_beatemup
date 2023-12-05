using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;

public class enemy : MonoBehaviour
{
    //------------GameObject Call Script------------
    private Player_Health player;
    private AttackUniversal enemyBlock;
    private PlayerAttack PlayerAttack;
    //------------GameObject------------
    public float damageTangan;
    public float damageKaki;
    public GameObject Tangan;
    public GameObject Kaki;
    public GameObject counterUI;

    //------------Health------------
    public int maxHP = 10;
    int currentHP;

    //------------Death------------
    protected bool dead;
    public event System.Action OnDeath;

    //------------Animation------------
    public Animator animator;

    //------------VFX-----------
    public VFXManager VFXManager;
    //------------SFX-----------
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip enemy_dead_sound;

    void Awake()
    {

        audioSource = GetComponent<AudioSource>();

    }

    public void Start()
    {
        player=GameObject.Find("Player").GetComponent<Player_Health>();
        enemyBlock=GameObject.Find("Player").GetComponent<AttackUniversal>();

        currentHP = maxHP;
        deActiveATK();
    }

    public void TakeDamage(int damageAmount)
    {
        if (enemyBlock.isEnemyBlock==true)                  
        {
            //jika enemy melakukan block maka value damage berkurang setengahNya
            damageAmount = Mathf.Max(1, damageAmount / 2);      
        }
        
        currentHP -= damageAmount;                  //Hp dikurang value damage
        
        if (currentHP <= 0)
        {
            Die();
            ScoreController.singleton.GetPoints(500f);
        } else
        {
            if(enemyBlock.isEnemyBlock==true)       //animasi enemy melakukan blocking
            {
                animator.SetTrigger("isBlock");
            } else                                  //effect getting Hit
            {
                animator.SetTrigger("damage");
            }
        }
    }
    protected void Die()
    {
        dead = true;
        if (OnDeath != null)
        {
            OnDeath();
        }

        GameObject.Destroy(gameObject, 2f);
        animator.SetTrigger("die");
        GetComponent<Collider>().enabled = false;
    }
    
    void Update()
    {
        if (player.OnPlayerDeath == true)         //if player death, enemy is celebrating
        {
            animator.SetTrigger("celebrated");
            deActiveATK();
        }
    }
    
    //------------TRIGER Damage------------
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Kaki.GetComponent<Collider>())
            {
                other.GetComponent<Player_Health>().TakeDamage(damageKaki);
            } else if (Tangan.GetComponent<Collider>())
            {
                other.GetComponent<Player_Health>().TakeDamage(damageTangan);
            }
        }
        if (other.tag == "Enemy")
        {
            deActiveATK();
            GetComponent<Collider>().enabled = false;
        }
    }

    //------------Animation Detect Collide------------
    public void ActiveATK()
    {
        Kaki.GetComponent<Collider>().enabled = true;
        Tangan.GetComponent<Collider>().enabled = true;
    }
    public void deActiveATK()
    {
        Kaki.GetComponent<Collider>().enabled = false;
        Tangan.GetComponent<Collider>().enabled = false;
    }
    //------------Animation Attack Detect Collide------------
    public void Punch()
    {
        Kaki.GetComponent<Collider>().enabled = false;
        Tangan.GetComponent<Collider>().enabled = true;
    }
    public void Kick()
    {
        Kaki.GetComponent<Collider>().enabled = true;
        Tangan.GetComponent<Collider>().enabled = false; 
    }

    public void enemy_sound_dead()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = enemy_dead_sound;
        audioSource.Play();
    }

    public void ONcounterattack()
    {
        Debug.Log("Counter attack");
        counterUI.SetActive(true);

        PlayerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();

        if (PlayerAttack != null)
        {
            PlayerAttack.EnableMovement();
        }
    }

    public void OFFcounterattack()
    {
        Debug.Log("OFFcounterattack called");
        counterUI.SetActive(false);

        PlayerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();

        if (PlayerAttack != null)
        {
            PlayerAttack.DisableMovement();
        }
    }

}