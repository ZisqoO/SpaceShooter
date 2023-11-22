using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShieldLoot : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * Time.deltaTime);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Playership"))
        {
            UIManager.Instance.energyBarImage.fillAmount += 0.2f;
            Destroy(gameObject);
        }
    }

}
