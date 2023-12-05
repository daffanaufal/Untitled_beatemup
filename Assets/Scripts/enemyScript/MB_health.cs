using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.XR;

public class MB_health : MonoBehaviour
{
    //------------GameObject------------
    private Player_Health player;
    public GameObject TanganL;
    public GameObject TanganR;
    public GameObject effectATK;

    public callMinion SpawnSt2;
    public callMinion SpawnMedkit;

    //------------Damage------------
    public float damageL;
    public float damageR;
    public bool isInvulnerable = false;

    //------------Death------------
    protected bool dead=true;
	public event System.Action OnDeath;

    //------------Animation------------
    public Animator animator;
   

    //------------Health------------
    //public Slider healthBar;
    public int maxHP;
    public int HPStageTwo;
    public int HPStageThree;
    int currentHP;

    //------------SFX----------------

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip scream, gethitboss, heavyatkmb, lightatkmb, walkingsound;


    //------------Start------------
    void Awake()
    {
        deActiveATK();
        deactiveVFX();
        audioSource = GetComponent<AudioSource>();
    }

    public void Start()
    {
        player=GameObject.Find("Player").GetComponent<Player_Health>();
        currentHP = maxHP;
        //healthBar.value= currentHP;
    }

    public void TakeDamage(int damageAmount)
    {
        if (isInvulnerable)
			return;
            
        currentHP -= damageAmount;
        Debug.Log("HP Enemy ="+currentHP);

        if (currentHP<=HPStageThree)
        {
            animator.SetTrigger("stageThree");
            SpawnMedkit.NextWave();
        }
        if (currentHP<=HPStageTwo)
        {
            animator.SetTrigger("stageTwo");
            SpawnSt2.NextWave();
            SpawnMedkit.NextWave();
        }

        if (currentHP <= 0)                         //-----Enemy is Dead
        {
            Die();
        } else                                      //-----Enemy is Hit
        {
            animator.SetTrigger("damage");
        }
    }
    protected void Die() 
    {
		dead = true;
		if (OnDeath != null) {
			OnDeath();
		}
        Debug.Log("BOss Death");
        animator.SetTrigger("die");
        GetComponent<Collider>().enabled=false;
        effectATK.GetComponent<Collider>().enabled=false;
	}

    void Update()
    {
        if (player.OnPlayerDeath == true)         //if player death, enemy is celebrating
        {
            animator.SetTrigger("celeb");
            deActiveATK();
        }
    }

    //------------Detect Trigger------------
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (TanganL.GetComponent<Collider>())
            {
                other.GetComponent<Player_Health>().TakeDamage(damageL);
            } else if (TanganR.GetComponent<Collider>())
            {
                other.GetComponent<Player_Health>().TakeDamage(damageR);
            } else if(effectATK.GetComponent<Collider>())
            {
                //timeSlow.DoSlowmotion();
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
        TanganR.GetComponent<Collider>().enabled = true;
        TanganL.GetComponent<Collider>().enabled = true;
    }
    public void deActiveATK()
    {
        TanganL.GetComponent<Collider>().enabled = false;
        TanganR.GetComponent<Collider>().enabled = false;
    }
    //------------Animation Attack Detect Collide------------
    public void LightATK()
    {
        TanganR.GetComponent<Collider>().enabled = false;
        TanganL.GetComponent<Collider>().enabled = true;
    }
    public void HeavyATK()
    {
        TanganR.GetComponent<Collider>().enabled = true;
        TanganL.GetComponent<Collider>().enabled = false;
    }

    //------------VFX ACTIVATION------------
    public void activeVFX()
    {
        effectATK.GetComponent<ParticleSystem>().Play();
        effectATK.GetComponent<Collider>().enabled=true;
    }
    public void deactiveVFX()
    {   
        effectATK.GetComponent<ParticleSystem>().Stop();
        effectATK.GetComponent<Collider>().enabled=false;
    }

    //---------------SFX--------------
    public void Scream_Sound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = scream;
        audioSource.Play();
    }

    void Get_Hit_Boss()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = gethitboss;
        audioSource.Play();
    }
    void Heavy_Attack()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = heavyatkmb;
        audioSource.Play();
    }

    void Light_Attack()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = lightatkmb;
        audioSource.Play();
    }

    void Walking_Sound()
    {
        audioSource.volume = 1f;
        audioSource.clip = walkingsound;
        audioSource.Play();
    }
    }