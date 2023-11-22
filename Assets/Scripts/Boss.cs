using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Boss : MonoBehaviour
{

    public int bossHealth = 250;

    public Transform bulletSpawnRight;
    public Transform bulletSpawnLeft;
    public Transform bulletSpawnMid;

    public GameObject specialBullet;
    public GameObject bulletPrefab;
    public GameObject bossExplosion;

    public Vector2 minBounds; // Minimum sýnýrlar
    public Vector2 maxBounds; // Maksimum sýnýrlar

    private Vector2 targetPosition; // Hedef konum
    private float lerpTime = 10f;   // Lerp iþleminin zamaný



    public float shipSpeed = 2f;
    public float bulletSpawnTime = 2f;

    private static Boss instance = null;
    public static Boss Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Boss>();
            }
            return instance;
        }
    }
    void Start()
    {
        targetPosition = GetRandomPosition();
        
        StartCoroutine(BossMovementCorotunie());


    }
    void FixedUpdate()
    {
       
    }
    private void Update()
    {
       
        
    }
    private Vector2 GetRandomPosition()
    {
        float x = Random.Range(minBounds.x, maxBounds.x);
        float y = Random.Range(minBounds.y, maxBounds.y);
       

        return new Vector2(x, y);
    }

    public void enemy_shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnRight.position, Quaternion.identity);
        Instantiate(bulletPrefab, bulletSpawnLeft.position, Quaternion.identity);
    }
    void Boss_Special_Shot()
    {
        Instantiate(specialBullet, bulletSpawnMid.position, Quaternion.identity);
    }   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            if(bossHealth > 10)
            {
                bossHealth -= 10;
                Debug.Log("Boss Health: "+bossHealth);
            }else if(bossHealth <= 10) 
            {
                Destroy(gameObject);
                GameObject EnemyExplode = Instantiate(bossExplosion, transform.position, Quaternion.identity);
                Destroy(EnemyExplode, 0.4f);
                GameManager.Instance.ScoreCount(500);
                UIManager.Instance.Activate_GameFinished_Tab(true);
            }
           

        }
        

    }
    IEnumerator BossMovementCorotunie()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            targetPosition = GetRandomPosition();
            float delta_X = targetPosition.x - transform.position.x;
            float delta_Y = targetPosition.y - transform.position.y;
            while (true)
            {
                float x = transform.position.x + (delta_X * Time.fixedDeltaTime);
                float y = transform.position.y + (delta_Y * Time.fixedDeltaTime);
                transform.position = new Vector2(x, y);
                yield return new WaitForSeconds(Time.fixedDeltaTime);
   
                if (Mathf.Abs(targetPosition.x - transform.position.x) < 0.2f && Mathf.Abs(targetPosition.y - transform.position.y) < 0.2f)
                {
                    
                    transform.position = targetPosition;
                    enemy_shoot();
                    Boss_Special_Shot();
                    break;
                }
            }
        
        }
        


    }
    
   
    
    
}
