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
    public GameObject gameOverCanvas;
    protected bool OnPlayerDeath; //ADD BOOLEAN

    private void FixedUpdate()
    {
        //Health Bar fill agar terlihat terisi
        healthUI.fillAmount = health / maxHealth;
    }

    public void TakeDamage(float damage, enemy Celebrate)
    {
        // Pengurangan health player apabila terkena serangan
        health -= damage;
        Debug.Log(health);

        GetComponentInChildren<Characteranimation>().Hit1(true);

        // Apabila nyawa 0, life berkurang dan nyawa akan kembali penuh
        if (health <= 0 && life > 0)
        {
            healthUIImg[life].SetActive(false);
            life--;
            health += 10;
        }

        // Kalau Player mati sementara dia reload Scene
        if (life == 0)
        {
            Die();
            Celebrate.ULose();
        }
    }

    protected void Die()
    {
        OnPlayerDeath=true;
        Debug.Log("dead");
        health = 0;
        GetComponentInChildren<Characteranimation>().Hit1(false);
        // Memanggil metode Die pada Characteranimation
        //GetComponentInChildren<Characteranimation>().Die();

        // Dead animation, Menu -> Active
        gameOverCanvas.SetActive(true);

        // Stop any movement
        //Time.timeScale = 0;
    }
}