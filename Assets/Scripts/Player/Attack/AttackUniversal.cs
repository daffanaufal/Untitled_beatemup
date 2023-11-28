using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;

    private int numHit=0;
    public int hitCount;
    public bool isEnemyBlock=true;
  
    public GameObject TanganKanan;
    public GameObject TanganKiri;
    public GameObject KakiKanan;
    public GameObject KakiKiri;
    
    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }
    
    public void DetectCollision_1()
    {
        Collider tangankananCollider = TanganKanan.GetComponent<Collider>();

        if (tangankananCollider != null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(tangankananCollider.transform.position, radius, collisionLayer);

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
                        numHit++;
                        if(numHit >= hitCount)
                        {
                            isEnemyBlock=true;
                        } else {isEnemyBlock=false;}
                    }
                }
            }
        }
    }
    public void DetectCollision_2()
    {
        Collider tangankiriCollider = TanganKiri.GetComponent<Collider>();

        if (tangankiriCollider != null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(tangankiriCollider.transform.position, radius, collisionLayer);

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
                        numHit++;
                        if(numHit >= hitCount)
                        {
                            isEnemyBlock=true;
                        } else {isEnemyBlock=false;}
                    }
                }
            }
        }
    }
    public void DetectCollision_3()
    {
        Collider kakikananCollider = KakiKanan.GetComponent<Collider>();

        if (kakikananCollider != null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(kakikananCollider.transform.position, radius, collisionLayer);

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
                        numHit++;
                        if(numHit >= hitCount)
                        {
                            isEnemyBlock=true;
                        } else {isEnemyBlock=false;}
                    }
                }
            }
        }
    }
    public void DetectCollision_4()
    {
        Collider kakikiriCollider = KakiKiri.GetComponent<Collider>();

        if (kakikiriCollider != null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(kakikiriCollider.transform.position, radius, collisionLayer);

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
                        numHit++;
                        if(numHit >= hitCount)
                        {
                            isEnemyBlock=true;
                        } else {isEnemyBlock=false;}
                    }
                }
            }
        }
    }
}
