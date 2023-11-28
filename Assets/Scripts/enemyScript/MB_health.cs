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
    public GameObject Tangan;
    public GameObject Kaki;

    //public hand Spawnn;

    //------------Damage------------
    public float damageAmount;

    //------------Death------------
    protected bool dead=true;
	public event System.Action OnDeath;

    //------------Animation------------
    public Animator animator;

    //------------Health------------
    //public Slider healthBar;
    public int maxHP = 1500;
    public int HPStageTwo = 1000;
    public int HPStageThree = 500;
    int currentHP;
    
    //------------Start------------
    public void Start()
    {
        player=GameObject.Find("Player").GetComponent<Player_Health>();
        currentHP = maxHP;
        //healthBar.value= currentHP;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHP -= damageAmount;
        
        if (currentHP <= HPStageThree)              //-----Enemy Stage Three
        { animator.SetTrigger("stageThree"); } 
        
        if (currentHP <= HPStageTwo)                //-----Enemy Stage Two
        {  
            animator.SetTrigger("stageTwo");
            //Spawnn.NextWave();                    //summoning minions
        } 

        if (currentHP <= 0 && !dead)                //-----Enemy is Dead
        {
            Die();
        } 
        else                                        //-----Enemy is Hit
        {
            animator.SetTrigger("damage");
            //AudioManager.instance.Play("enemyGetHit");
        }
    }
    
    protected void Die() 
    {
		dead = true;
		if (OnDeath != null) {
			OnDeath();
		}
		GameObject.Destroy (gameObject);
        animator.SetTrigger("die");
        GetComponent<Collider>().enabled=false;
	}

    void Update()
    {
        if (player.OnPlayerDeath==true)
        {
            animator.SetTrigger("celeb");
        }
    }

    //------------Detect Trigger------------
    public void OnTriggerEnter(Collider other)
    {
        if (Kaki.GetComponent<Collider>()||Tangan.GetComponent<Collider>())
        {
            if (other.tag =="Player")
            {
                other.GetComponent<Player_Health>().TakeDamage(damageAmount);
            }
        }
    }

    //------------Animation Detect Collide------------
    public void activeAttack()
    {
        Tangan.GetComponent<Collider>().enabled=true;
        Kaki.GetComponent<Collider>().enabled=true;
    }
    public void deactiveAttack()
    {
        Tangan.GetComponent<Collider>().enabled=false;
        Kaki.GetComponent<Collider>().enabled=false;
    }
}