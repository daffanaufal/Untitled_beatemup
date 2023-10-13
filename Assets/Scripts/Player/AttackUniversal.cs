using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;
    public GameObject hit_FX;

    // Tombol yang akan digunakan untuk menyerang
    public KeyCode attackKey = KeyCode.Space;

    void Update()
    {
        // Cek apakah tombol serangan ditekan
        if (Input.GetKey(attackKey))
        {
            DetectCollision();
        }
    }

    void DetectCollision()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        foreach (Collider col in hitColliders)
        {
            if (col.CompareTag("Enemy"))
            {
                // Ambil komponen 'enemy' dari objek musuh yang terkena pukulan
                enemy enemyComponent = col.GetComponent<enemy>();

                if (enemyComponent != null)
                {
                    // Panggil metode TakeDamage pada komponen enemy
                    enemyComponent.TakeDamage((int)damage);
                }
            }
        }
    }
}
