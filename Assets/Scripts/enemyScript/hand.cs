using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") //&& enemy status == "attack"
        {
            other.GetComponent<Player_Health>().TakeDamage(0.5f);
            Debug.Log("Hit");
        }

    }
}
