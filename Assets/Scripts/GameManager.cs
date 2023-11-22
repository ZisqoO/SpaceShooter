using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    

    public GameObject playerExplosion;
    public GameObject player;
    public GameObject shield;

    
    public GameObject enemyship1;
    public GameObject enemyship2;
    public GameObject boss;

    public bool canDamaged = true;

    public int scorePoint;
    
    public float respawnTime = 2f;

    int health = 100;

    public float shipSpeed = 4f;


    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }
    void Start()
    {
        StartCoroutine(Enemy_Spawner());
        shield.gameObject.SetActive(false);
    }

    
    void Update()
    {
        
    }
    public void ScoreCount(int amount)
    {
        scorePoint += amount;
        UIManager.Instance.IncraseScore();

    }
    public void Shield()
    {
        StartCoroutine(Shield_Numerator());
    }
    IEnumerator Shield_Numerator()
    {
        if(UIManager.Instance.energyBarImage.fillAmount > 0)
        {
            float j = (UIManager.Instance.energyBarImage.fillAmount * 10) / 2; // shield bar nekadar dolu ise oran düþmeye baþlayacak.
            Debug.Log("J deðeri: " + j);
            canDamaged = false;
            shield.gameObject.SetActive(true);
            //while (true)

            for (float i = j; i >= 0; i--)
            {
                float shieldPercentage = i / 5.0f;
                UIManager.Instance.ShieldBar(shieldPercentage);
                yield return new WaitForSeconds(1);
                if (i == 0)
                {
                    shield.gameObject.SetActive(false);

                }
                //  4= 80/100
            }
            canDamaged = true;
            yield return null;
        }
        
       
        
     
       


    }
    
    public void Player_Dmg_Taken(int damage)
    {
        
        if (health > 10)
        {
            health -= damage;
          
            UIManager.Instance.HealthBar(health/100f);

        }
        else
        {
            Destroy(player.gameObject);
            UIManager.Instance.HealthBar(0);
            GameObject explosion = Instantiate(playerExplosion, player.transform.position, Quaternion.identity);
            explosion.transform.localScale = new Vector2(6,6);
            Destroy(explosion, 0.4f);
            UIManager.Instance.Activate_GameOver_Tab(true);
        }



    }
    
    IEnumerator Enemy_Spawner()
    {
        int spawnCalculator = 1;
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            
            spawnCalculator++;
            //Debug.Log("SpawnCalculator :" + spawnCalculator);
            if(spawnCalculator < 30)
            {
                Enemy_Spawn1();
            }else if(spawnCalculator >= 30 && spawnCalculator <60)
            {
                Enemy_Spawn2();
            }
            else if(spawnCalculator == 60)
            {
                break;
            }
        }
        Instantiate(boss, new Vector2(0, 3.5f), Quaternion.identity);
        Debug.Log("while dýþýna çýktý");

    }
    void Enemy_Spawn1()
    {
        int randpomPosX = Random.Range(7, -7);
        Instantiate(enemyship1, new Vector2(randpomPosX, transform.position.y), Quaternion.identity);
    }
    void Enemy_Spawn2()
    {
        int randpomPosX = Random.Range(7, -7);
        Instantiate(enemyship2, new Vector2(randpomPosX, transform.position.y), Quaternion.identity);
    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Boss_hit(float value)
    {
        
        StartCoroutine(Boss_OnHit(value));
    }
    IEnumerator Boss_OnHit(float value)
    {
        shipSpeed = 1.0f;
        Debug.Log("ilk Speed: " + shipSpeed);
        yield return new WaitForSeconds(value);
        shipSpeed = 4.0f;
        Debug.Log("ikinci Speed: " +shipSpeed);
    }
    
    


}
