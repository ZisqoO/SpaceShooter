using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Enemy : MonoBehaviour
{
    public Enemy_Type enemyType;
    int shipHealth;
    public GameObject shieldLoot;
    public Transform bulletSpawn;
    //public GameObject MenemyBullet;
    //public GameObject enemyExplosionPrefab;
    //private GameObject ship;

    public float shipSpeed = 1f;
    public float bulletSpawnTime = 3f;

    private static Enemy instance = null;
    public static Enemy Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Enemy>();
            }
            return instance;
        }
    }
    void Start()
    {
        
        StartCoroutine(Enemy_Shooting());
        shipHealth = enemyType.health;
        

    }
    void FixedUpdate()
    {
        //ship.transform.Translate(Vector2.down * shipSpeed * Time.deltaTime);
        transform.Translate(Vector2.down * shipSpeed * Time.deltaTime);
    }
    
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            if(enemyType.enemyTypeNo == 1)
            {
                Debug.Log("Enemy Type -1");
                SoundManager.Instance.SoundPlayer(SoundManager.Instance.enemyDestroySound);
                Destroy(gameObject);
                EnemyLoot();
                GameObject EnemyExplode = Instantiate(enemyType.explosionPrefab, transform.position, Quaternion.identity);
                Destroy(EnemyExplode, 0.4f);
                GameManager.Instance.ScoreCount(enemyType.scorePoint);
            }
            if(enemyType.enemyTypeNo == 2)
            {
                Debug.Log("Enemy Type = -2");
                if(shipHealth > 0)
                {
                    shipHealth -= 10;
                    if (shipHealth == 0)
                    {
                        SoundManager.Instance.SoundPlayer(SoundManager.Instance.enemyDestroySound);
                        Destroy(gameObject);
                        EnemyLoot();
                        GameObject EnemyExplode = Instantiate(enemyType.explosionPrefab, transform.position, Quaternion.identity);
                        Destroy(EnemyExplode, 0.4f);
                        GameManager.Instance.ScoreCount(enemyType.scorePoint);
                    }
                }
                
                
                
            }
            
            
        }
        

    }
    public void EnemyLoot()
    {
        int range = Random.Range(0, 10);
        Debug.Log("Range: " + range);
        if (range < 2)
        {
            Instantiate(shieldLoot, transform.position, Quaternion.identity);
        }
    }
    IEnumerator Enemy_Shooting()
    {
        while (true)
        {
            enemy_shoot();
            yield return new WaitForSeconds(bulletSpawnTime);
        }
    }
    void enemy_shoot()
    {
        Instantiate(enemyType.bulletPrefab, bulletSpawn.position, Quaternion.identity);
    }

}
