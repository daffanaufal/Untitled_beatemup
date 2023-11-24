using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    
    //public float health; //Nyawa yang ditampilkan
    public int life, point; // banyak "life"
    public GameObject[] maxHealth;
    public Image healthUI; //Fill amount nyawa
    public GameObject[] healthUIImg; //life count apabila health sudah 0, life akan deactive
    public GameObject gameOverCanvas;
    protected bool OnPlayerDeath; //ADD BOOLEAN

    private void FixedUpdate()
    {

    }

    public void TakeDamage(float damage, enemy Celebrate)
    {
        // Pengurangan health player apabila terkena serangan
        //health -= damage;
        //Debug.Log(health);

        GetComponentInChildren<Characteranimation>().Hit1(true);

        if(damage >= 4)
        {
            float multipleMinus = damage / 4f;
            for (int i = 0; i <= 25; i++)
            {
                maxHealth[point].SetActive(false);
                point--;
            }
        }

        // Apabila nyawa 0, life berkurang dan nyawa akan kembali penuh
        if (point <= 0 && life > 0)
        {
            healthUIImg[life].SetActive(false);
            life--;
            for(int i = 0; i <= 25; i++)
            {
                maxHealth[i].SetActive(true);
            }
        }

        // Kalau Player mati sementara dia reload Scene
        if (life == 0)
        {
            Die();
            Celebrate.ULose();
            // Dead animation, Menu -> Active
            gameOverCanvas.SetActive(true);

            // Stop any movement
            //Time.timeScale = 0
        }
    }

    protected void Die()
    {
        OnPlayerDeath=true;
        Debug.Log("dead");
        //health = 0;
        GetComponentInChildren<Characteranimation>().Hit1(false);
        // Memanggil metode Die pada Characteranimation
        GetComponentInChildren<Characteranimation>().Die();
    }
}