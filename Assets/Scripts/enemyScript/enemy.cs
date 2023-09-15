using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int maxHP = 10;
    int currentHP;

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
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled=false;
        } 
        else
        {
            animator.SetTrigger("damage");
        }
    }
}
