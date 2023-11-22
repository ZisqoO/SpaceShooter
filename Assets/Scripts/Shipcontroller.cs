using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shipcontroller : MonoBehaviour
{
    float minX,maxX, minY, maxY;
    //public float speed = 4f;

    public GameObject playerBullet;
    public Transform bulletPosition;
    //public float speed = 4f;

    private static Shipcontroller instance = null;
    public static Shipcontroller Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Shipcontroller>();
            }
            return instance;
        }
    }
    private void Start()
    {
        
        //Ship Movement Boundires
        minX = -7.5f;
        maxX = 7.5f;
        minY = -4f;
        maxY = 4f;
    }
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * GameManager.Instance.shipSpeed * Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical") * GameManager.Instance.shipSpeed * Time.deltaTime;

        float posX = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        float posY = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);
        transform.position = new Vector2(posX, posY);

        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(Player_Shooting(0.1f));
            //Instantiate(playerBullet, bulletPosition.position, Quaternion.identity);
            //SoundManager.Instance.SoundPlayer(SoundManager.Instance.playerBulletSound);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.Shield();
        }
    }
    private void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) // enemy ile çarpýþýnca her ikisi de yok olmasý için.
    {
        if (collision.CompareTag("Enemyship"))
        {
            if (GameManager.Instance.canDamaged)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                UIManager.Instance.HealthBar(0);
                GameObject explosion = Instantiate(GameManager.Instance.playerExplosion, transform.position, Quaternion.identity);
                Destroy(explosion, 0.4f);

                UIManager.Instance.Activate_GameOver_Tab(true);
            }
                
        }
        else if (collision.CompareTag("EnemyBullet"))
        {
            if (GameManager.Instance.canDamaged)
            {
                UIManager.Instance.ColorAlphaChange(); // damage yiyince sprite renderer kapanýp açýlsýn diye yaptým ama olmuyor.
                GameManager.Instance.Player_Dmg_Taken(10);
            }
            
            
        }
        else if (collision.CompareTag("EnemyBullet2"))
        {
            if (GameManager.Instance.canDamaged)
            {
                UIManager.Instance.ColorAlphaChange();
                GameManager.Instance.Player_Dmg_Taken(20);
            }
                
        }
        else if (collision.CompareTag("BossBullet"))
        {
            
            {
                GameManager.Instance.Player_Dmg_Taken(20);
                GameManager.Instance.Boss_hit(2);
            }
                
        }
        else if (collision.CompareTag("ParticleBullet"))
        {
            if (GameManager.Instance.canDamaged)
            {
                GameManager.Instance.Player_Dmg_Taken(10);
                GameManager.Instance.Boss_hit(1);
            }
               
        }

    }
    IEnumerator Player_Shooting(float value)
    {
        Instantiate(playerBullet, bulletPosition.position, Quaternion.identity);
        SoundManager.Instance.SoundPlayer(SoundManager.Instance.playerBulletSound);
        yield return new WaitForSeconds(value);
    }
    


}
