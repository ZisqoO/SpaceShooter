using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    public bool isEnemy;
    public float speed;
     void FixedUpdate()
    {
        if(isEnemy)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }else if(!isEnemy)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }

}
