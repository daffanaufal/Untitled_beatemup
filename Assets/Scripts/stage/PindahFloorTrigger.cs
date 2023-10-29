using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PindahFloorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Dapatkan objek pemain
            GameObject player = other.gameObject;

            // Pindahkan pemain ke posisi yang ditentukan
            player.transform.position = new Vector3(-33.01f, 0.05f, -1.04f);
        }
    }
}
