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

    //------------VFX-----------
    public VFXManager VFXManager;


    public void Start()
    {
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
        GetComponent<Collider>().enabled=false;
	}
    public void ULose()
    {
        animator.SetTrigger("celebrated");
        Debug.Log("Enemy Celebrated");
        deActiveATK();
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
    //------------VFX--------------
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == enemy)
        {
        

		// kita jalankan VFX saat tabrakan dengan bola pada posisi tabrakannya
		VFXManager.PlayVFX(collision.transform.position);
        }
    }
}