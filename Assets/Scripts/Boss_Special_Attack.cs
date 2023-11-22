using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Special_Attack : MonoBehaviour
{
    public GameObject bullet_Particle;
    public float speed = 0.5f;
    
    void Start()
    {
        Invoke("Particle_Attack", 1f);
    }

    
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * Time.deltaTime);
    }
    public void Particle_Attack()
    {
       

        for (float i = 0; i < 6; i++)
        {
            GameObject particle = Instantiate(bullet_Particle, transform.position, Quaternion.identity);
            
            particle.transform.Rotate(Vector3.forward, i * 60);
            particle.transform.position = new Vector3(particle.transform.position.x,particle.transform.position.y, 0);
            
            Destroy(particle,3f);
        }
        Destroy(gameObject);
    }
    
}
