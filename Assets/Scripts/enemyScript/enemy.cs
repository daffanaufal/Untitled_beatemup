using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;

public class enemy : MonoBehaviour
{
    //------------GameObject------------
    private Player_Health player;
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
        player=GameObject.Find("Player").GetComponent<Player_Health>();

        currentHP = maxHP;
        deActiveATK();
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
        }
    }
    protected void Die() 
    {
		dead = true;
		if (OnDeath != null) {
			OnDeath();
		}
		GameObject.Destroy (gameObject,2f);
        animator.SetTrigger("die");
        GetComponent<Collider>().enabled = false;
    }
    void Update()
    {
        if (player.OnPlayerDeath==true)         //if player death, enemy is celebrating
        {
            animator.SetTrigger("celebrated");
            deActiveATK();
        }
    }
    
    //------------TRIGER Damage------------
    public void OnTriggerEnter(Collider other)
    {
        if (Kaki.GetComponent<Collider>()||Tangan.GetComponent<Collider>())
        {
            if (other.tag =="Player")
            {
                other.GetComponent<Player_Health>().TakeDamage(damage);
            }
        }
        if (other.tag=="Enemy")
        {
            deActiveATK();
            GetComponent<Collider>().enabled=false;
        }
    }

    //------------Animation Detect Collide------------
    public void ActiveATK()
    {
        Kaki.GetComponent<Collider>().enabled=true;
        Tangan.GetComponent<Collider>().enabled=true;
    }
    public void deActiveATK()
    {
        Kaki.GetComponent<Collider>().enabled=false;
        Tangan.GetComponent<Collider>().enabled=false;
    }
    //------------Animation Attack Detect Collide------------
    public void Punch()
    {
        Kaki.GetComponent<Collider>().enabled=false;
        Tangan.GetComponent<Collider>().enabled=true;
    }
    public void Kick()
    {
        Kaki.GetComponent<Collider>().enabled=true;
        Tangan.GetComponent<Collider>().enabled=false;
    }
}