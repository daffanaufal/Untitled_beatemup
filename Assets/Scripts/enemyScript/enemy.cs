using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;

public class enemy : MonoBehaviour
{
    //------------GameObject------------
    public float damage;
    public GameObject Tangan;
    public GameObject Kaki;

    //------------Health------------
    public int maxHP = 10;
    int currentHP;

    //------------Death------------
    protected bool dead;
	public event System.Action OnDeath;

    //------------Animation------------
    public Animator animator;
    
    public void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHP -= damageAmount;
        if (currentHP <= 0)
        {
            Die();
        } 
        else
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
		GameObject.Destroy (gameObject,2.5f);
        animator.SetTrigger("die");
        GetComponent<Collider>().enabled=false;
        //AudioManager.instance.Play("enemyDeath");
	}
    public void ULose()
    {
        animator.SetTrigger("celebrated");
        Debug.Log("Enemy Celebrated");
        GetComponent<Collider>().enabled=false;
    }

    //------------TRIGER Damage------------
    public void OnTriggerEnter(Collider other)
    {
        if (Kaki.GetComponent<Collider>()||Tangan.GetComponent<Collider>())
        {
            if (other.tag =="Player")
            {
                other.GetComponent<Player_Health>().TakeDamage(damage, this);
            }
        }
        if (other.tag=="Enemy")
        {
            Kaki.GetComponent<Collider>().enabled=false;
            Tangan.GetComponent<Collider>().enabled=false;
        }
    }

    //------------Animation Detect Collide------------
}