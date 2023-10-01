using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int maxHP = 10;
    int currentHP;

    protected bool dead;
	public event System.Action OnDeath;

    public Animator animator;
    public Slider healthBar;
    
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
}