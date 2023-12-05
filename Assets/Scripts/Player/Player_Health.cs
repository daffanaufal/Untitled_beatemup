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
    //protected bool OnPlayerDeath; //ADD BOOLEAN
    public bool OnPlayerDeath=true;
    [SerializeField] private LayerMask medkitLayer;
    private Playermovement playerMovement;
    private enemy enemy;

    private void Update()
    {
        //Health Bar fill agar terlihat terisi
       healthUI.fillAmount = health / maxHealth;
    }

    void Start()
    {
        // Get the Player_Health component
        playerMovement = GetComponent<Playermovement>();
    }

    public void TakeDamage(float damage)
    {
        // Pengurangan health player apabila terkena serangan
        if (!playerMovement.isGuarding)
        {
            health -= damage;
            GetComponentInChildren<Characteranimation>().Hit1(true);

            // Apabila nyawa 0, life berkurang dan nyawa akan kembali penuh
            if (health <= 0 && life >= 0)
            {
                healthUIImg[life].SetActive(false);
                life--;
                health += maxHealth;
            }
        }
        else
        {
            damage = 0;
            GetComponentInChildren<Characteranimation>().Hit1(false);
            Debug.Log("Sedang guarding");
        }

        // Kalau Player mati sementara dia reload Scene
        if (life == 0)
        {
            Die();

            OnPlayerDeath = true;     //Player Die
            // Dead animation, Menu -> Active
            gameOverCanvas.SetActive(true);

            // Stop any movement
            //Time.timeScale = 0
        }
    }

    void Die()
    {
        //Debug.Log("dead");
        health = 0;
        GetComponentInChildren<Characteranimation>().Hit1(false);
        // Memanggil metode Die pada Characteranimation
        GetComponentInChildren<Characteranimation>().Die();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Cek apakah objek yang bersentuhan memiliki layer "Medkit"
        if (other.gameObject.layer == LayerMask.NameToLayer("Medkit"))
        {
            // Ambil komponen script dari objek yang bersentuhan
            Medkit medkit = other.GetComponent<Medkit>();

            // Cek apakah komponen Medkit ada
            if (medkit != null)
            {
                // Tambahkan health dan maxHealth dari Medkit
                health += medkit.healthBonus;
                maxHealth += medkit.maxHealthBonus;

                // Batasi health dan maxHealth agar tidak lebih dari 100
                health = Mathf.Min(health, 100f);
                maxHealth = Mathf.Min(maxHealth, 100f);

                // Aktifkan kembali life UI jika health lebih besar dari 0
                if (health > 0 && life < healthUIImg.Length)
                {
                    healthUIImg[life].SetActive(true);
                }


            }
        }
    }
}
