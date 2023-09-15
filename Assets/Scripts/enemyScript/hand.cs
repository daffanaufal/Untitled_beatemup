using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour
{
    public int damageAmount = 2;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {
            other.GetComponent<Playermovement>().TakeDamage(damageAmount);
        }
    }
}
