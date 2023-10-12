using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    
    public float health; //Nyawa yang ditampilkan
    public int life; // banyak "life"
    public float maxHealth; //Bar hitam pada health bar, agar terlihat seperti terisi
    public Image healthUI; //Fill amount nyawa
    public GameObject[] healthUIImg; //life count apabila health sudah 0, life akan deactive
<<<<<<< Updated upstream
    public GameObject gameOverCanvas;
=======
    public GameObject gameOverUI;
>>>>>>> Stashed changes

    private void FixedUpdate()
    {
        //Health Bar fill agar terlihat terisi
        healthUI.fillAmount = health / maxHealth;
    }

    public void TakeDamage(float damage)
    {
        //Pengurangan health player apabila terkena serangan
        health -= damage;

        //Apabila nyawa 0, life berkurang dan nyawa akan kembali penuh
        if (health <= 0 && life > 0)
        {
            healthUIImg[life].SetActive(false);
            life--;
            health += 10;

        }

        //Kalau Player mati sementara dia reload Scene
        if (life == 0)
        {
            health = 0;
            Debug.Log("dead");
            //Dead animation , Menu -> Active
<<<<<<< Updated upstream
            gameOverCanvas.SetActive(true);

=======
            gameOverUI.SetActive(true);
>>>>>>> Stashed changes
            //stop any movement
            Time.timeScale = 0;
        }
    }
}