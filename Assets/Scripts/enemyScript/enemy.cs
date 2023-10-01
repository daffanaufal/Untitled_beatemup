using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;

public class enemy : MonoBehaviour
{
    //------------GameObject------------
    public GameObject Tangan;
    public GameObject Kaki;
    
    //------------Health------------
    public int maxHP = 10;
    int currentHP;
    public Slider healthBar;

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
		GameObject.Destroy (gameObject,1f);
        animator.SetTrigger("die");
        GetComponent<Collider>().enabled=false;
        //AudioManager.instance.Play("enemyDeath");
	}

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